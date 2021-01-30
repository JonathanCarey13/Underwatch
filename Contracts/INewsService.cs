using Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface INewsService
    {
        bool CreateNews(CreateNewsViewModel viewModel);
        IEnumerable<NewsListItem> GetNews();
        NewsDetail GetNewsById(int id);
        bool UpdateNews(NewsEdit model);
        bool DeleteNews(int newsId);
        void DropDownCreate(CreateNewsViewModel viewModel);
        void DropDownEdit(NewsEdit model);
    }
}
