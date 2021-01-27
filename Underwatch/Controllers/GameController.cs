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
    [Authorize]
    public class GameController : Controller
    {
        // Get: Game/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            var model = service.GetGames();

            return View(model);
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

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your Game was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong! The Game couldn't be created.");

            return View(model);
        }

        // Get: Game/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameById(id);

            return View(model);
        }

        // Get: Game/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var detail = service.GetGameById(id);
            var model =
                new GameEdit
                {
                    GameId = detail.GameId,
                    Title = detail.Title,
                    Genre = detail.Genre,
                    ReleaseDate = detail.ReleaseDate,
                    IsReleased = detail.IsReleased,
                    EarlyAccess = detail.EarlyAccess,
                    GameWebsite = detail.GameWebsite,
                    IsOwned = detail.IsOwned,
                };
            return View(model);
        }

        // Post: Game/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id does not match");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your Game was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }

        // Get: Game/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameById(id);

            return View(model);
        }

        // Post: Game/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your Game was deleted!";

            return RedirectToAction("Index");
        }
        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }
    }
}