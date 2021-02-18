using Microsoft.Extensions.Logging;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Classes.Helpers;
using Web.Areas.Customer.ViewModels;
using System.Security.Claims;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly IEmailService _emailSender;
        private readonly IKupacService kupacService;
        private readonly IGradoviService gradoviService;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,ILogger<AccountController> logger, IEmailService emailSender,IKupacService kupacService,IGradoviService gradoviService)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this._emailSender = emailSender;
            this.kupacService = kupacService;
            this.gradoviService = gradoviService;
        }


        //GET
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.Gradovi = gradoviService.GetGradovi().Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.Id.ToString(),
                                              Text = a.Ime
                                          }).ToList();
            return View(model);
        }

        //POST
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                

                if (result.Succeeded)
                {

                    var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                    MailRequest mail = new MailRequest
                    {
                        Subject = "Confirm your account",
                        Body = "Please confirm your account by clicking this link: <a href =\"" + confirmationLink + "\">link</a>",
                        ToEmail = model.Email
                    };
                    await _emailSender.SendEmailAsync(mail);

                    kupacService.InsertKupac(model.convertToKupac(user));

                    if (SignInManager.IsSignedIn(User) && User.IsInRole("Administrator"))
                    {
                        return RedirectToAction("ListUsers", "Administration", new { area = "Admin" });
                    }

                    return View("SuccessfulRegistration");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            model.Gradovi = gradoviService.GetGradovi().Select(a =>
                             new SelectListItem
                             {
                                 Value = a.Id.ToString(),
                                 Text = a.Ime
                             }).ToList();
            return View(model);
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail ( string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await UserManager.FindByIdAsync(userId);

            if(user==null)
            {
                ViewBag.ErrorMessage = $"The user ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await UserManager.ConfirmEmailAsync(user, token);

            if(result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            model.ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);

                if(user!= null & !user.EmailConfirmed && (await UserManager.CheckPasswordAsync(user,model.Password)))
                {

                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View(model);
                }
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                    ModelState.AddModelError(string.Empty,"Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("index");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });

            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError=null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await SignInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if(remoteError!=null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
                return View("Login", loginViewModel);
            }

            var info = await SignInManager.GetExternalLoginInfoAsync();
            if(info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information.");
                return View("Login", loginViewModel);
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            ApplicationUser user = null;

            if(email!= null)
            {
                user = await UserManager.FindByEmailAsync(email);
                if(user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");
                    return View("Login", loginViewModel);
                }
            }

            var signInResult = await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if(signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
             

                if(email != null)
                {

                    if(user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        await UserManager.CreateAsync(user);

                        var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                        var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token = token }, Request.Scheme);

                        MailRequest mail = new MailRequest
                        {
                            Subject = "Confirm your account",
                            Body = "Please confirm your account by clicking this link: <a href =\"" + confirmationLink + "\">link</a>",
                            ToEmail = user.Email
                        };
                        await _emailSender.SendEmailAsync(mail);

                        return View("SuccessfulRegistration");
                    }

                    await UserManager.AddLoginAsync(user, info);
                    await SignInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }

                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support on defiance_main@outlook.com";
                return View("Error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if(user != null && await UserManager.IsEmailConfirmedAsync(user))
                {
                    var token = await UserManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { email = model.Email, token = token }, Request.Scheme);
                    MailRequest mail = new MailRequest
                    {
                        Subject = "Confirm password reset",
                        Body = "Please reset your password by clicking this link: <a href =\"" + passwordResetLink + "\">link</a>",
                        ToEmail = model.Email
                    };
                    await _emailSender.SendEmailAsync(mail);
                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var user = await UserManager.GetUserAsync(User);
                    if (user == null)
                    {
                        return RedirectToAction("Login");
                    }

                    // ChangePasswordAsync changes the user password
                    var result = await UserManager.ChangePasswordAsync(user,
                        model.CurrentPassword, model.NewPassword);

                    // The new password did not meet the complexity rules or
                    // the current password is incorrect. Add these errors to
                    // the ModelState and rerender ChangePassword view
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View();
                    }

                    // Upon successfully changing the password refresh sign-in cookie
                    await SignInManager.RefreshSignInAsync(user);
                    return View("ChangePasswordConfirmation");
                }

                return View(model);
            }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await UserManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await UserManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return View("ResetPasswordConfirmation");
            }
            // Display validation errors if model state is not valid
            return View(model);
        }


        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}
