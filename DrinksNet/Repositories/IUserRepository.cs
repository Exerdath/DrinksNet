using System;
using DrinksNet.AuxApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using DrinksNet.Controllers;
using DrinksNet.Domain;

namespace DrinksNet.AuxApi
{
    public interface IUserRepository
    {
        Task<User> FindUserOnLogin(UserLoginDto user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<int>> GetUserDrinks(int userId);
    }
}
