using System.Web.Mvc;

namespace Sinbin.Web.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile/Picture
        [Authorize]
        public ActionResult Picture()
        {
            return View();
        }
    }
}