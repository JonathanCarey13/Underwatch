using Models.Game;
using Models.News;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FavoritesList
{
    public class FavoritesCreate
    {
        public int ListId { get; set; }
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual GameCreate Game { get; set; }
        [ForeignKey(nameof(News))]
        public int NewsId { get; set; }
        public virtual NewsCreate News { get; set; }

    }
}
