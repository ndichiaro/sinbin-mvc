using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Sinbin.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinbin.UserManager
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<User>
    {
        public static IdentityContext CreateContext()
        {
            return IdentityContext.Create();
        }

        public ApplicationUserManager(IUserStore<User> store)
            : base(store)
        {
        }
        
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<User>(context.Get<IdentityContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        /// <summary>
        /// updates the user availability by the user's Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="available"></param>
        /// <returns></returns>
        public bool UpdateUserAvailability(string id, bool available)
        {
            using (var ctx = IdentityContext.Create())
            {
                var controller = new User();
                var user = controller.FindById(ctx, id);
                user.Active = available;
                return controller.Update(ctx, user).Active;
            }
        }
        /// <summary>
        /// updates the user availability by the user's email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="available"></param>
        /// <returns></returns>
        public bool UpdateUserAvailabilityByEmail(string email, bool available)
        {
            using (var ctx = IdentityContext.Create())
            {
                var controller = new User();
                var user = controller.FindByEmail(ctx, email);
                user.Active = available;
                return controller.Update(ctx, user).Active;
            }
        }

        /// <summary>
        /// Updates the users location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<string> UpdateLocationAsync(string id, decimal latitude, decimal longitude)
        {
            using (var ctx = IdentityContext.Create())
            {
                var controller = new User();
                var user = await FindByIdAsync(id);
                user.Latitude = latitude;
                user.Longitude = longitude;
                user.LastLocationCheck = DateTime.Now;
                return await controller.UpdateLocationAsync(ctx, user);
            }
        }
    }
}
