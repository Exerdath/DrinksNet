using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinksNet.AuxApi.Dtos;

namespace DrinksNet.DAL
{
    public interface IUsersDataAccessLayer
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserForLogin(string email, string password);
    }
}
