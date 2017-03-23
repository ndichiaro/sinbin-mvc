﻿using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sinbin.ApplicationManager
{
    public class CustomPasswordValidator : IIdentityValidator<string>
    {
        public int RequiredLength { get; set; }

        public CustomPasswordValidator(int length)
        {
            RequiredLength = length;
        }

        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(string.Format("Password should be of length {0}", RequiredLength)));
            }
            string pattern = @"^(?=.*[0-9])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*0-9]{10,}$";

            if (!Regex.IsMatch(item, pattern))
            {
                return Task.FromResult(IdentityResult.Failed("Passwords must have one numeral and one special character"));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}