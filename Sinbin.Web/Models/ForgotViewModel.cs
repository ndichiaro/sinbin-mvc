﻿using System.ComponentModel.DataAnnotations;

namespace Sinbin.Web.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}