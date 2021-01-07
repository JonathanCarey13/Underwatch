using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.News
{
    public class CreateNewsViewModel
    {
        public IEnumerable<SelectListItem> Games { get; set; }      // Where the information for the drop down list is being stored
        public int GameId { get; set; }                             // Keeps track of which one is selected

    }
}
