using Contracts;
using Data;
using Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Underwatch.Data;

namespace Services
{
    public class NewsService : INewsService
    {
        private readonly Guid _userId;

        public NewsService()
        {
            
        }

        public bool CreateNews(CreateNewsViewModel viewModel)
        {
            var entity =
                new News()
                {
                    OwnerId = _userId,
                    GameId = viewModel.GameId,
                    UpdateTitle = viewModel.UpdateTitle,
                    Description = viewModel.Description,
                    IsDLC = viewModel.IsDLC,
                    IsUpdate = viewModel.IsUpdate,
                    UpdateReleaseDate = viewModel.UpdateReleaseDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.News_s.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NewsListItem> GetNews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .News_s
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NewsListItem
                                {
                                    NewsId = e.NewsId,
                                    GameId = e.GameId,
                                    UpdateTitle = e.UpdateTitle,
                                    Description = e.Description,
                                    IsDLC = e.IsDLC,
                                    IsUpdate = e.IsUpdate,
                                    UpdateReleaseDate = e.UpdateReleaseDate,
                                    Title = e.Game.Title
                                }
                        );

                return query.ToArray();
            }
        }

        public NewsDetail GetNewsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .News_s
                        .Single(e => e.NewsId == id && e.OwnerId == _userId);
                return
                    new NewsDetail
                    {
                        NewsId = entity.NewsId,
                        GameId = entity.GameId,
                        UpdateTitle = entity.UpdateTitle,
                        Description = entity.Description,
                        IsDLC = entity.IsDLC,
                        IsUpdate = entity.IsUpdate,
                        UpdateReleaseDate = entity.UpdateReleaseDate,
                        Title = entity.Game.Title
                    };
            }
        }

        public bool UpdateNews(NewsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .News_s
                        .Single(e => e.NewsId == model.NewsId && e.OwnerId == _userId);

                entity.GameId = model.GameId;
                entity.UpdateTitle = model.UpdateTitle;
                entity.Description = model.Description;
                entity.IsDLC = model.IsDLC;
                entity.IsUpdate = model.IsUpdate;
                entity.UpdateReleaseDate = model.UpdateReleaseDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteNews(int newsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .News_s
                        .Single(e => e.NewsId == newsId && e.OwnerId == _userId);

                ctx.News_s.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public void DropDownCreate(CreateNewsViewModel viewModel)
        {
            var ctx = new ApplicationDbContext();

            viewModel.Games =
                ctx
                .Games
                .Where(e => e.OwnerId == _userId)
                .Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.GameId.ToString()
                });
        }
        public void DropDownEdit(NewsEdit model)
        {
            var ctx = new ApplicationDbContext();

            model.Games =
                ctx
                .Games
                .Where(e => e.OwnerId == _userId)
                .Select(c => new SelectListItem
                {
                    Text = c.Title,
                    Value = c.GameId.ToString()
                });
        }
    }
}
