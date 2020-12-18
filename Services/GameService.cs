using Data;
using Models;
using Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Underwatch.Data;

namespace Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Genre = model.Genre,
                    ReleaseDate = model.ReleaseDate,
                    IsReleased = model.IsReleased,
                    EarlyAccess = model.EarlyAccess,
                    GameWebsite = model.GameWebsite,
                    IsOwned = model.IsOwned,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    Title = e.Title,
                                    Genre = e.Genre,
                                    ReleaseDate = e.ReleaseDate,
                                    IsReleased = e.IsReleased,
                                    EarlyAccess = e.EarlyAccess,
                                    GameWebsite = e.GameWebsite,
                                    IsOwned = e.IsOwned,
                                }
                        );

                return query.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == id && e.OwnerId == _userId);
                return
                    new GameDetail
                    {
                        GameId = entity.GameId,
                        Title = entity.Title,
                        Genre = entity.Genre,
                        ReleaseDate = entity.ReleaseDate,
                        IsReleased = entity.IsReleased,
                        EarlyAccess = entity.EarlyAccess,
                        GameWebsite = entity.GameWebsite,
                        IsOwned = entity.IsOwned,
                    };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == model.GameId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Genre = model.Genre;
                entity.ReleaseDate = model.ReleaseDate;
                entity.IsReleased = model.IsReleased;
                entity.EarlyAccess = model.EarlyAccess;
                entity.GameWebsite = model.GameWebsite;
                entity.IsOwned = model.IsOwned;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameId && e.OwnerId == _userId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}
