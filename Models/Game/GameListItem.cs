using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GameListItem
    {
        public int GameId { get; set; }
        [Display(Name = "Game Title")]
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Display(Name="Is it Released?")]
        public bool IsReleased { get; set; }
        [Display(Name = "Is it still Early Access?")]
        public bool EarlyAccess { get; set; }
        [Display(Name = "Game Website Link")]
        public Uri GameWebsite { get; set; }
        [Display(Name = "Do you own it?")]
        public bool IsOwned { get; set; }
    }
}
