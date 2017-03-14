using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Sinbin.FileUpload;
using Sinbin.UserManager;
using Sinbin.Web.Helpers;
using Sinbin.Web.Models;

namespace Sinbin.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        #region Varibles

        private ApplicationUserManager _userManager;
        private readonly IFileStorage _fileStorage;
        #endregion

        #region Properties
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Constructors

        public ProfileController()
        {
            _fileStorage = new AmazonFileStorage();
        }
        #endregion

        #region Controllers
        // GET: Profile/Picture
        [Authorize]
        public async Task<ActionResult> Picture()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var viewModel = new PictureViewModel
            {
                ProfilePictureUrl = user.ProfilePicture,
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Picture(PictureViewModel model)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                // if newly posted file
                if (model.ProfilePicture != null)
                {
                    var url = _fileStorage.Write(FileHelpers.ConvertEmailToFileName(user.Email, model.ProfilePicture.FileName),
                    FileHelpers.GetPostedFileBytes(model.ProfilePicture));
                    if (string.IsNullOrEmpty(url))
                    {
                        // display error
                    }
                    user.ProfilePicture = url;
                }
                UserManager.Update(user);
                // add randomId parameter so that the css will pull the updated
                // profile picture rather than the cached. This is because the url
                // always remains the same for the user
                model.ProfilePictureUrl = user.ProfilePicture + $"?randomId={ Guid.NewGuid() }";
            }
            return View(model);
        }
        #endregion
    }
}