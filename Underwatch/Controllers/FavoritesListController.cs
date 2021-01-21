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
        // Get: FavoritesList/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoritesService(userId);
            var model = service.GetFavorites();

            return View(model);
        }

        // Get: FavoritesList/Create
        public ActionResult Create()
        {
            var viewModel = new CreateFavoritesListViewModel();
            var service = CreateFavoritesService();

            service.DropDownCreate(viewModel);

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

            var service = CreateFavoritesService();
            service.DropDownCreate(viewModel);

            var userId = Guid.Parse(User.Identity.GetUserId());
            service = new FavoritesService(userId);

            service.CreateFavorites(viewModel);

            return RedirectToAction("Index");
        }

        // Get: FavoritesList/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateFavoritesService();
            var model = service.GetFavoritesById(id);

            return View(model);
        }

        // Get: FavoritesList/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateFavoritesService();
            service.GetFavoritesById(id);

            var model = new FavoritesEdit();
            model.ListId = id;
            service.DropDownEdit(model);


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

            var service = CreateFavoritesService();
            model.ListId = id;
            service.DropDownEdit(model);

            if (service.UpdateFavorites(model))
            {
                TempData["SaveResult"] = "Your Favorites was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Favorites could not be updated because something went Whoopsie-Doodle!");
            return View(model);
        }

        // Get: FavoritesList/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = CreateFavoritesService();
            var model = service.GetFavoritesById(id);

            return View(model);
        }

        // Post: FavoritesList/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFavorite(int id)
        {
            var service = CreateFavoritesService();
            service.DeleteFavorite(id);

            TempData["SaveResult"] = "A Favorite was successfully deleted!";

            return RedirectToAction("Index");
        }

        // Service Method
        private FavoritesService CreateFavoritesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoritesService(userId);
            return service;
        }
    }
}