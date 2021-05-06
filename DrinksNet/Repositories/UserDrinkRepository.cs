using System.Threading.Tasks;
using DrinksNet.DAL;

namespace DrinksNet.Repositories
{
    public class UserDrinkRepository : IUserDrinkRepository
    {
        private readonly IUserDrinksDataAccessLayer _userDrinksDataAccessLayer;
        private bool disposed = false;


        public UserDrinkRepository(IUserDrinksDataAccessLayer userDrinksDataAccessLayer)
        {
            _userDrinksDataAccessLayer = userDrinksDataAccessLayer;
        }

        public void FavouriteDrink(int userId, int drinkId)
        {
            _userDrinksDataAccessLayer.AddDrinkToUser(userId, drinkId);
        }

        public void UnFavouriteDrink(int userId, int drinkId)
        {
            _userDrinksDataAccessLayer.RemoveDrinkFromUser(userId, drinkId);
        }
    }
}
