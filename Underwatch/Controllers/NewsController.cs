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
        // Get: News/Index
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NewsService(userId);
            var model = service.GetNews();

            return View(model);
        }

        // Get: News/Create
        public ActionResult Create()
        {
            var viewModel = new CreateNewsViewModel();
            var service = CreateNewsService();

            service.DropDownCreate(viewModel);

            return View(viewModel);
        }

        // Post: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateNewsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var service = CreateNewsService();
            service.DropDownCreate(viewModel);

            var userId = Guid.Parse(User.Identity.GetUserId());
            service = new NewsService(userId);

            service.CreateNews(viewModel);

            return RedirectToAction("Index");
        }

        // Get: News/Details/{id}
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
            var model = new NewsEdit
            {
                NewsId = detail.NewsId,
                UpdateTitle = detail.UpdateTitle,
                Description = detail.Description,
                IsDLC = detail.IsDLC,
                IsUpdate = detail.IsUpdate,
                UpdateReleaseDate = detail.UpdateReleaseDate,
            };

            model.NewsId = id;
            service.DropDownEdit(model);

            return View(model);
        }

        // Post: News/Edit/{id}
        [HttpPost]
        [ActionName("Edit")]
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
            model.NewsId = id;
            service.DropDownEdit(model);

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

        // Service Method
        private NewsService CreateNewsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NewsService(userId);
            return service;
        }
    }
}