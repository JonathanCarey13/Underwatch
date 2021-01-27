using Models.FavoritesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFavoritesService
    {
        bool CreateFavorites(CreateFavoritesListViewModel viewModel);
        IEnumerable<FavoritesListItem> GetFavorites();
        FavoritesDetails GetFavoritesById(int id);
        bool UpdateFavorites(FavoritesEdit model);
        bool DeleteFavorite(int listId);
        void DropDownCreate(CreateFavoritesListViewModel viewModel);
        void DropDownEdit(FavoritesEdit model);

    }
}
