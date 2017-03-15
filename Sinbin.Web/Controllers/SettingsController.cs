using System.Web.Mvc;

namespace Sinbin.Web.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Menu()
        {
            return View();
        }
    }
}