using Contracts;
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
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // Get: News/Index
        public ActionResult Index()
        {
            var model = _newsService.GetNews();

            return View(model);
        }

        // Get: News/Create
        public ActionResult Create()
        {
            var viewModel = new CreateNewsViewModel();

            _newsService.DropDownCreate(viewModel);

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

            _newsService.DropDownCreate(viewModel);

            if (_newsService.CreateNews(viewModel))
            {
                TempData["SaveResult"] = "Your News was created!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong! The News couldn't be created.");

            return View(viewModel);
        }

        // Get: News/Details/{id}
        public ActionResult Details(int id)
        {
            var model = _newsService.GetNewsById(id);

            return View(model);
        }

        // Get: News/Edit/{id}
        public ActionResult Edit(int id)
        {
            var detail = _newsService.GetNewsById(id);
            var model = new NewsEdit
            {
                NewsId = detail.NewsId,
                GameId = detail.GameId,
                UpdateTitle = detail.UpdateTitle,
                Description = detail.Description,
                IsDLC = detail.IsDLC,
                IsUpdate = detail.IsUpdate,
                UpdateReleaseDate = detail.UpdateReleaseDate,
            };

            model.NewsId = id;
            _newsService.DropDownEdit(model);

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

            model.NewsId = id;
            _newsService.DropDownEdit(model);

            if (_newsService.UpdateNews(model))
            {
                TempData["SaveResult"] = "Your News was updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your News could not be updated.");
            return View(model);
        }

        // Get: News/Delete/{id}
        public ActionResult Delete(int id)
        {
            var model = _newsService.GetNewsById(id);

            return View(model);
        }

        // Post: News/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            _newsService.DeleteNews(id);

            TempData["SaveResult"] = "Your News was deleted";

            return RedirectToAction("Index");
        }
    }
}