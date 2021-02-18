using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Customer.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }


        [Required(ErrorMessage = "Morate unjeti kontakt telefon")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(06)\d\s*\d{3}\s*\d{3}", ErrorMessage = "Format vaseg broja nije dobar, probajte sa 06X XXX XXX")]
        public string BrojMobitela { get; set; }

        public string FullPhone { get; set; }

        [Required(ErrorMessage = "Izaberite grad molimo vas")]
        [Range(1, int.MaxValue, ErrorMessage = "Izaberite vas grad molimo vas")]
        public int GradId { get; set; }

        public List<SelectListItem> Gradovi { get; set; }

        public Kupac convertToKupac(ApplicationUser user)
        {
            return new Kupac
            {
                Email = Email,
                Ime = Ime,
                Prezime = Prezime,
                GradId = GradId,
                ApplicationUser = user,
                BrojMobitela = FullPhone
            };
        }

    }
    }

