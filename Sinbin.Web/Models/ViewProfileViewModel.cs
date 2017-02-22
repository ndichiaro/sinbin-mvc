﻿using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Sinbin.Web.Models
{
    public class ViewProfileViewModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Profile Picture")]
        public HttpPostedFileBase ProfilePicture { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Profile Picture Url")]
        public string ProfilePictureUrl { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}