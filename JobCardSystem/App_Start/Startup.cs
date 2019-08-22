using System;
using System.Collections.Generic;
using System.Linq;
using JobCardSystem.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using JobCardSystem.Models;
using JobCardSystem.Persistence;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(JobCardSystem.Startup))]

namespace JobCardSystem
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
            SeedDropDownListContent();
        }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }

        public static void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                //
                var user = new ApplicationUser();
                user.UserName = "admin@group.com";
                user.Email = "admin@group.com";
                user.IdNumber = "00000000";
                user.PhoneNumber = "0311008096";
                user.Name = "Admin";
                user.Surname = "Istrator";
                user.LockoutEnabled = false;
                user.EmailConfirmed = false;
                user.TwoFactorEnabled = false;
                user.AreaId = 1;


                string userPassword = "password1234";

                var chkUser = userManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }

            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Technician"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Technician";
                roleManager.Create(role);
            }
        }

        public static void SeedDropDownListContent()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var exist = context.MaintenanceContracts.ToList().Count();
            if (exist == 0)
            {
                var maintenanceContractList = new List<MaintenanceContract>()
                {
                    new MaintenanceContract()
                    {
                        Name = "Monthly",
                        Duration = 1
                    },
                    new MaintenanceContract()
                    {
                        Name = "Semi Annual",
                        Duration = 6
                    },
                    new MaintenanceContract()
                    {
                        Name = "Quarterly",
                        Duration = 3
                    },
                    new MaintenanceContract()
                    {
                        Name = "Yearly",
                        Duration = 12
                    }
                };

                var serviceContractList = new List<ServiceContract>()
                {
                    new ServiceContract()
                    {
                        ServiceName = "Monthly",
                        Months = 1
                    },
                    new ServiceContract()
                    {
                        ServiceName = "Quarterly",
                        Months = 3
                    },
                    new ServiceContract()
                    {
                        ServiceName = "Semi Annually",
                        Months = 6
                    },
                    new ServiceContract()
                    {
                        ServiceName = "Yearly",
                        Months = 12
                    }
                };

                var jobTypeList = new List<JobType>()
                {
                    new JobType()
                    {
                        Name = "Maintenance Check"
                    },
                    new JobType()
                    {
                        Name = "Installation"
                    },
                    new JobType()
                    {
                        Name = "Repair"
                    }
                };

                var jobStatusList = new List<JobStatus>()
                {
                    new JobStatus()
                    {
                        Name = "Complete"
                    },
                    new JobStatus()
                    {
                        Name = "Pending"
                    },
                    new JobStatus()
                    {
                        Name = "Open"
                    }
                };
                context.JobStatuses.AddRange(jobStatusList);
                context.JobTypes.AddRange(jobTypeList);
                context.ServiceContracts.AddRange(serviceContractList);
                context.MaintenanceContracts.AddRange(maintenanceContractList);
                context.SaveChanges();
            }
        }
    }
}