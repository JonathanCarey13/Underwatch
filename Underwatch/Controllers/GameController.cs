using Data;
using Microsoft.AspNet.Identity;
using Models;
using Models.Game;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Underwatch.Data;

namespace Underwatch.Controllers
{
    [Authorize]     // This allows for only logged in users to access this, I'll need to uncomment it out later
    public class GameController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();        //This is also part of the GeneralStoreMVC

        // Get: Game/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            var model = service.GetGames();

            return View(model);

            //This is from the GeneralStoreMVC guide
            //List<Game> gameList = _db.Games.ToList();
            //List<Game> orderedGameList = gameList.OrderBy(game => game.Title).ToList();
            //return View(orderedGameList);
        }

        // Get: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // Post: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);

            service.CreateGame(model);

            return RedirectToAction("Index");

        }





    }
}