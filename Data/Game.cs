using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsReleased { get; set; }
        public bool EarlyAccess { get; set; }
        public string GameWebsite { get; set; }
        public bool IsOwned { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
    }
}
