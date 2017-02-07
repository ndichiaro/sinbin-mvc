using Sinbin.UserManager;
using Sinbin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sinbin.Web.Controllers
{
    [Authorize]
    public class FeedController : Controller
    {
        private FeedManager _manager;

        public FeedController()
        {
            _manager = new FeedManager();
        }

        // GET: Feed
        public ActionResult Index()
        {
            var feed = _manager.GetFeed(User.Identity.Name);
            var tiles = new List<Tile>();
            foreach (var tile in feed)
            {
                tiles.Add(new Tile
                {
                    Image = tile.ProfilePicture,
                    Active = tile.Active
                });
            }

            return View(tiles);
        }
    }
}