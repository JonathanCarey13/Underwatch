using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Underwatch.Models;

namespace Data
{
    public class FavoritesList
    {
        [Key]
        public int ListId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        [ForeignKey(nameof(News))]
        public int NewsId { get; set; }
        public virtual News News { get; set; }

    }
}
