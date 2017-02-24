﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool Active { get; set; }
        public DateTime? LastLogin { get; set; }
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
        public IEnumerable<User> GetUsers(IdentityContext ctx)
        {
            return ctx.Users.ToList();
        }

        // return the user the contains the id 
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
        #endregion
    }
}
