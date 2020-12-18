﻿using Data;
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

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong! The game couldn't be made.");

            return View(model);
        }

        // Get: Game/Details
        public ActionResult Details(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameById(id);

            return View(model);
        }

        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }

        
        



    }
}