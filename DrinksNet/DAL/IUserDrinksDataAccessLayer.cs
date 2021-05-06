using System.Collections.Generic;
using System.Threading.Tasks;
using DrinksNet.Domain.Dtos;
using MongoDB.Driver;

namespace DrinksNet.DAL
{
    public interface IUserDrinksDataAccessLayer
    {
        Task<IEnumerable<UserDrinkDto>> GetAllUserDrinks();
        Task<List<int>> GetUserDrinks(int userId);
        void AddDrinkToUser(int userId, int drinkId);
        void RemoveDrinkFromUser(int userId, int drinkId);
    }
}
