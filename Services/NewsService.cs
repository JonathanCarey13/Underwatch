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
    public class NewsService
    {
        private readonly Guid _userId;

        public NewsService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNews(NewsCreate model)
        {
            var entity =
                new News()
                {
                    OwnerId = _userId,
                    GameId = model.GameId,
                    UpdateTitle = model.UpdateTitle,
                    Description = model.Description,
                    IsDLC = model.IsDLC,
                    IsUpdate = model.IsUpdate,
                    UpdateReleaseDate = model.UpdateReleaseDate
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
                                    UpdateReleaseDate = e.UpdateReleaseDate
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
                        UpdateReleaseDate = entity.UpdateReleaseDate
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

                entity.UpdateTitle = model.UpdateTitle;
                entity.Description = model.Description;
                entity.IsDLC = model.IsDLC;
                entity.IsUpdate = model.IsUpdate;
                entity.UpdateReleaseDate = model.UpdateReleaseDate;

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
