using System;
using System.Threading.Tasks;
using AutoMapper;
using DrinksNet.AuxApi;
using DrinksNet.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinksNet.Controllers
{
    [Route("api/{controller}")]
    public class UserController: Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<User[]>> Get()
        {
            try
            {
                var result = await _userRepository.GetAllUsers();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody]UserLoginDto userLogin)
        {
            try
            {
                var result = await _userRepository.FindUserOnLogin(userLogin);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }
}
