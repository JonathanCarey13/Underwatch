using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.FavoritesList
{
   public class CreateFavoritesListViewModel
    {
        public IEnumerable<SelectListItem> Games { get; set; }
        public int GameId { get; set; }
        public IEnumerable<SelectListItem> News_s { get; set; }
        public int NewsId { get; set; }
    }
}
