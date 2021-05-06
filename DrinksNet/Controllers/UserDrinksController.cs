using System;
using DrinksNet.Domain;
using DrinksNet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinksNet.Controllers
{
    [Route("{controller}")]
    public class UserDrinksController : Controller
    {
        private IUserDrinkRepository _repository;

        public UserDrinksController(IUserDrinkRepository userDrinkRepository)
        {
            _repository = userDrinkRepository;
        }

        [HttpPost]
        public IActionResult FavouriteDrink([FromBody] UserDrink userDrink)
        {
            try
            {
                _repository.FavouriteDrink(userDrink.UserId, userDrink.DrinkId);
                return Ok(userDrink.DrinkId);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        [Route("unFaveDrink")]
        public IActionResult UnFavouriteDrink([FromBody] UserDrink userDrink)
        {
            try
            {
                _repository.UnFavouriteDrink(userDrink.UserId, userDrink.DrinkId);
                return Ok(userDrink.DrinkId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
