using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sinbin.Data.EF
{
    public class User : IdentityUser
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime? LastLocationCheck { get; set; }
        public bool Availability { get; set; }
        public bool Online { get; set; }
        #endregion

        #region Async Methods
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers(IdentityContext ctx)
        {
            return await ctx.Users.ToListAsync();
        }

        /// <summary>
        /// Gets all online users that are not the calling user.
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetOnlineUsers(IdentityContext ctx, string username)
        {
            return await ctx.Users
                            .Where(x => x.UserName != username && x.Online)
                            .ToListAsync();
        }

        /// <summary>
        /// return the user the contains the id 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public User FindById(IdentityContext ctx, string id)
        {
            return ctx.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Update(IdentityContext ctx, User user)
        {
            var result = FindById(ctx, user.Id);
            ctx.Entry(result).CurrentValues.SetValues(user);
            ctx.SaveChanges();
            return result;
        }

        /// <summary>
        /// returns the user that contails the email parameter
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public User FindByEmail(IdentityContext ctx, string email)
        {
            return ctx.Users.FirstOrDefault(x => x.Email == email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> UpdateLocationAsync(IdentityContext ctx, User user)
        {
            var result = FindById(ctx, user.Id);
            ctx.Entry(result).CurrentValues.SetValues(user);
            await ctx.SaveChangesAsync();
            return result.Id;
        }
        #endregion
    }
}
