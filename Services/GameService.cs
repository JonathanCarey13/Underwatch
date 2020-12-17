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
    }
}
