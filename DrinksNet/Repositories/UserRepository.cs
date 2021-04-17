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
        private UsersDataAccessLayer _usersDataAccessLayer = new UsersDataAccessLayer();
        private bool disposed = false;
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
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
    }
}
