using AutoMapper;
using DrinksNet.Controllers;
using DrinksNet.DAL;
using DrinksNet.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinksNet.AuxApi
{
    public class UserRepository: IUserRepository
    {
        private readonly IUsersDataAccessLayer _usersDataAccessLayer;
        private readonly IUserDrinksDataAccessLayer _userDrinksDataAccessLayer;
        private bool disposed = false;
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper, IUsersDataAccessLayer usersDataAccessLayer, IUserDrinksDataAccessLayer userDrinksDataAccessLayer)
        {
            _mapper = mapper;
            _usersDataAccessLayer = usersDataAccessLayer;
            _userDrinksDataAccessLayer = userDrinksDataAccessLayer;
        }


        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var allUsers = await _usersDataAccessLayer.GetAllUsers();
            return _mapper.Map<User[]>(allUsers);
        }

        public async Task<User> FindUserOnLogin(UserLoginDto user)
        {
            var loggedUser = await _usersDataAccessLayer.GetUserForLogin(user.Email, user.Password);
            var loggedUserResponse = _mapper.Map<User>(loggedUser);
            return loggedUserResponse;
        }

        public async Task<IEnumerable<int>> GetUserDrinks(int userId)
        {
            var allUsers = await _userDrinksDataAccessLayer.GetUserDrinks(userId);
            return allUsers;
        }
    }
}
