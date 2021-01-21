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
        public IEnumerable<SelectListItem> Games { get; set; }
        public int GameId { get; set; }
    }
}
