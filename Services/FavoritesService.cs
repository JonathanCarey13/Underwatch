﻿using Data;
using Models.FavoritesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Underwatch.Data;

namespace Services
{
    public class FavoritesService
    {
        private readonly Guid _userId;

        public FavoritesService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFavorites(CreateFavoritesListViewModel viewModel)
        {
            var entity =
                new FavoritesList()
                {
                    OwnerId = _userId,
                    GameId = viewModel.GameId,
                    NewsId = viewModel.NewsId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.FavoriteLists.Add(entity);
                return ctx.SaveChanges() == 1;              // Double check here
            }
        }

        public IEnumerable<FavoritesListItem> GetFavorites()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .FavoriteLists
                        .Where(e => e.OwnerId == _userId)
                            .Select(
                                e =>
                                    new FavoritesListItem
                                    {
                                        ListId = e.ListId,
                                        NewsId = e.NewsId,
                                        GameId = e.GameId
                                    }
                            );

                return query.ToArray();
            }
        }

        public FavoritesDetails GetFavoritesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FavoriteLists
                        .Single(e => e.ListId == id && e.OwnerId == _userId);
                return
                    new FavoritesDetails
                    {
                        ListId = entity.ListId,
                        NewsId = entity.NewsId,
                        GameId = entity.GameId
                    };
            }
        }

        public bool UpdateFavorites(FavoritesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FavoriteLists
                        .Single(e => e.ListId == model.ListId && e.OwnerId == _userId);

                entity.NewsId = model.NewsId;
                entity.GameId = model.GameId;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteFavorite(int listId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FavoriteLists
                        .Single(e => e.ListId == listId && e.OwnerId == _userId);

                ctx.FavoriteLists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
