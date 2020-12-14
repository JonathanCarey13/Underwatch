using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        virtual public Game Game { get; set; }
        public bool IsDLC { get; set; }
        public bool IsUpdate { get; set; }
        public bool UpdateTitle { get; set; }
        public string Description { get; set; }
        public DateTime UpdateReleaseDate { get; set; }
    }
}
