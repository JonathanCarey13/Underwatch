using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.News
{
    public class NewsCreate
    {
        [Required]
        [Display(Name = "Game")]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual GameListItem Game { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 characters.")]
        [MaxLength(50, ErrorMessage = "Whoa there partner! Lets trim down a few sentences shall we? Maybe under 300 characters?")]
        [Display(Name = "Update Title")]
        public string UpdateTitle { get; set; }
        [Display(Name = "Description")]
        [MaxLength(300, ErrorMessage ="Whoa there partner! Lets trim down a few sentences shall we? Maybe under 300 characters?")]
        public string Description { get; set; }
        [Display(Name = "DLC")]
        public bool IsDLC { get; set; }
        [Display(Name = "Free Content Update")]
        public bool IsUpdate { get; set; }
        [Display(Name = "Release Date mm/dd/yyyy")]
        public DateTime UpdateReleaseDate { get; set; }
    }
}
