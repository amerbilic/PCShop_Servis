using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccessLayer;
using RepositoryLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.Classes.Interfaces;
using ServiceLayer.Classes;
using ServiceLayer.Classes.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MailKit;

namespace PCShop_Servis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<MyContext>()
            .AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IGradoviService, GradoviService>();
            services.AddTransient<IKupacService, KupacService>();
            services.AddTransient<IArtikliService, ArtikalService>();
            services.AddTransient<INarudzbaService, NarudzbaService>();
            services.AddTransient<IProizvodjaciService, ProizvodjaciService>();
            services.AddTransient<IEmailService, EmailService>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddMvc(options => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "1052684782300-iqd7ak7f637rkpeip07hooo4m901vqo7.apps.googleusercontent.com";
                    options.ClientSecret = "72Pf5YTVtBvw0ZcZMhrjaj-J";
                });

            services.AddSession();
            services.AddHttpContextAccessor();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Customer/Account/Login";
                options.LogoutPath = $"/Customer/Account/Logout";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Custom exception handler for logging users exceptions.
                app.UseExceptionHandler("/Customer/Customer/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area=Admin}/{controller=Administration}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Customer",
                    pattern: "{area=Customer}/{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
