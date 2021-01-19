using Models.Game;
using Models.News;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.FavoritesList
{
    public class FavoritesEdit
    {
        public int ListId { get; set; }
        [Required]
        [Display(Name = "Game Title")]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual GameListItem Game { get; set; }
        [Display(Name = "News Title")]
        [ForeignKey(nameof(News))]
        public int NewsId { get; set; }
        public virtual NewsEdit News { get; set; }
        [Display(Name ="Game")]
        public string Title { get; set; }
        [Display(Name = "Update Title")]
        public string UpdateTitle { get; set; }
        public IEnumerable<SelectListItem> Games { get; set; }
        public IEnumerable<SelectListItem> News_s { get; set; }
    }
}
