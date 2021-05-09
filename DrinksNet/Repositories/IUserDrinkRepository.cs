using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinksNet.Repositories
{
    public interface IUserDrinkRepository
    {
        void FavouriteDrink(int userId, int drinkId);
        void UnFavouriteDrink(int userId, int drinkId);
        Task<int[]> GetUserDrinks(int userId);


    }
}
