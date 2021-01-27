using Models;
using Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGameService
    {
        bool CreateGame(GameCreate model);
        IEnumerable<GameListItem> GetGames();
        GameDetail GetGameById(int id);
        bool UpdateGame(GameEdit model);
        bool DeleteGame(int gameId);
    }
}
