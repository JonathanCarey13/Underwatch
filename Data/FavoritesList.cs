using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FavoritesList
    {
        [Key]
        public int ListId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        virtual public User User { get; set; }
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        virtual public Game Game { get; set; }
        [ForeignKey(nameof(News))]
        public int NewsId { get; set; }
        virtual public News News { get; set; }

    }
}
