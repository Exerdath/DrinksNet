using System.Threading.Tasks;

namespace DrinksNet.Repositories
{
    public interface IUserDrinkRepository
    {
        void FavouriteDrink(int userId, int drinkId);
        void UnFavouriteDrink(int userId, int drinkId);


    }
}
