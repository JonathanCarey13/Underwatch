using Contracts;
using Microsoft.AspNet.Identity;
using Models.FavoritesList;
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
    public class FavoritesListController : Controller
    {
        private readonly IFavoritesService _favoritesService;

        public FavoritesListController(IFavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }

        // Get: FavoritesList/Index
        public ActionResult Index()
        {
            var model = _favoritesService.GetFavorites();

            return View(model);
        }

        // Get: FavoritesList/Create
        public ActionResult Create()
        {
            var viewModel = new CreateFavoritesListViewModel();

            _favoritesService.DropDownCreate(viewModel);

            return View(viewModel);
        }

        // Post: FavoritesList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFavoritesListViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _favoritesService.DropDownCreate(viewModel);

            if (_favoritesService.CreateFavorites(viewModel))
            {
                TempData["SaveResult"] = "Your Underwatch was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong! The Underwatch couldn't be created.");

            return View(viewModel);
        }

        // Get: FavoritesList/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _favoritesService.GetFavoriteById(id);

            return View(model);
        }

        // Get: FavoritesList/Edit/{id}
        public ActionResult Edit(int id)
        {
            var detail = _favoritesService.GetFavoriteById(id);
            var model = new FavoritesEdit
            {
                ListId = detail.ListId,
                NewsId = detail.NewsId,
                GameId = detail.GameId,
            };

            model.ListId = id;
            _favoritesService.DropDownEdit(model);

            return View(model);
        }

        // Post: Favorites/Edit/{id}
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FavoritesEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ListId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            model.ListId = id;
            _favoritesService.DropDownEdit(model);

            if (_favoritesService.UpdateFavorites(model))
            {
                TempData["SaveResult"] = "The Underwatch was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Underwatch could not be updated because something went Whoopsie-Doodle!");
            return View(model);
        }

        // Get: FavoritesList/Delete/{id}
        public ActionResult Delete(int id)
        {
            var model = _favoritesService.GetFavoriteById(id);

            return View(model);
        }

        // Post: FavoritesList/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFavorite(int id)
        {
            _favoritesService.DeleteFavorite(id);

            TempData["SaveResult"] = "An Underwatch was successfully deleted!";

            return RedirectToAction("Index");
        }
    }
}