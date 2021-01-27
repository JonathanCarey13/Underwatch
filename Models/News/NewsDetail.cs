using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.News
{
    public class NewsDetail
    {
        public int NewsId { get; set; }
        [Display(Name = "Game")]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual GameListItem Game { get; set; }
        [Display(Name = "Update Title")]
        public string UpdateTitle { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "DLC")]
        public bool IsDLC { get; set; }
        [Display(Name = "Free Content Update")]
        public bool IsUpdate { get; set; }
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdateReleaseDate { get; set; }
        [Display(Name = "Game")]
        public string Title { get; set; }
    }
}
