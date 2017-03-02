using Sinbin.UserManager;
using Sinbin.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sinbin.Web.Controllers
{
    [Authorize]
    public class FeedController : Controller
    {
        private readonly FeedManager _manager;

        public FeedController()
        {
            _manager = new FeedManager();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // Feed/Feed
        [HttpGet]
        [Authorize]
        public async Task<JsonResult> Feed()
        {
            var feed = await _manager.GetFeed(User.Identity.Name);
            var tiles = new List<TileViewModel>();
            foreach (var tile in feed)
            {
                tiles.Add(new TileViewModel
                {
                    Image = tile.ProfilePicture,
                    Active = tile.Availability
                });
            }

            return Json(tiles, JsonRequestBehavior.AllowGet);
        }
    }
}