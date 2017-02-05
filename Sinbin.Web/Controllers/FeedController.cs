using Sinbin.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sinbin.Web.Controllers
{
    public class FeedController : Controller
    {
        // GET: Feed
        public ActionResult Index()
        {
            var tiles = new List<Tile>()
            {
                new Tile { Image = "http://c.directlyrics.com/img/upload/selena-gomez-revival-promo-pic.jpg", Active = true },
                new Tile { Image = "https://s-media-cache-ak0.pinimg.com/originals/a6/18/64/a6186459266bfaa86be41f49cb4ffd80.jpg", Active = true },
                new Tile { Image = "https://s-media-cache-ak0.pinimg.com/564x/30/2c/04/302c04caddb748657eb9edb65b76eb72.jpg", Active = true },
                new Tile { Image = "/https://s-media-cache-ak0.pinimg.com/originals/3c/7a/45/3c7a45141b07f8af548f262159b1edb3.jpg", Active = true }
            };
            
            return View(tiles);
        }
    }
}