using Microsoft.AspNet.Identity;
using Models.News;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Underwatch.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private Data.ApplicationDbContext _db = new Data.ApplicationDbContext();

        // Get: News/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NewsService(userId);
            var model = service.GetNews();

            return View(model);
        }

        // ViewData/ViewBags
        // Get: News/Create
        public ActionResult Create()
        {
            ViewData["Games"] = _db.Games.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.GameId.ToString()
            });

            return View();
        }

        // Post: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ViewData["Games"] = _db.Games.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.GameId.ToString()
            });
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service =  new NewsService(userId);

            service.CreateNews(model);

            return RedirectToAction("Index");
        }

        // Get: News/Details
        public ActionResult Details(int id)
        {
            var service = CreateNewsService();
            var model = service.GetNewsById(id);

            return View(model);
        }
        
        // Get: News/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateNewsService();
            var detail = service.GetNewsById(id);
            var model =
                new NewsEdit
                {
                    NewsId = detail.NewsId,
                    UpdateTitle = detail.UpdateTitle,
                    Description = detail.Description,
                    IsDLC = detail.IsDLC,
                    IsUpdate = detail.IsUpdate,
                    UpdateReleaseDate = detail.UpdateReleaseDate,
                };

            return View(model);
        }

        // Post: News/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NewsId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNewsService();

            if (service.UpdateNews(model))
            {
                TempData["SaveResult"] = "Your News was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your news could not be updated.");
            return View(model);
        }

        // Get: News/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = CreateNewsService();
            var model = service.GetNewsById(id);

            return View(model);
        }

        // Post: News/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNewsService();
            service.DeleteNews(id);

            TempData["SaveResult"] = "Your news was deleted";

            return RedirectToAction("Index");
        }

        private NewsService CreateNewsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NewsService(userId);
            return service;
        }
    }
}