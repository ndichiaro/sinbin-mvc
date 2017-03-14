using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Sinbin.Web.Models
{
    public class PictureViewModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Profile Picture")]
        public HttpPostedFileBase ProfilePicture { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Profile Picture Url")]
        public string ProfilePictureUrl { get; set; }
    }
}