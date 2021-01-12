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
    public class FavoritesListItem
    {
        public int ListId { get; set; }
        [Required]
        [Display(Name="Game Title")]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual GameListItem Game { get; set; }
        [Display(Name ="News Title")]
        [ForeignKey(nameof(News))]
        public int NewsId { get; set; }
        public virtual NewsListItem News { get; set; }
    }
}
