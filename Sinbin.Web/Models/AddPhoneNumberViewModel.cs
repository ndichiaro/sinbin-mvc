using System.ComponentModel.DataAnnotations;

namespace Sinbin.Web.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}