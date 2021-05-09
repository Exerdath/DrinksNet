using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrinksNet.AuxApi;
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
        private ICocktailRepository _drinkRepository;
        private IMapper _mapper;

        public UserDrinksController(IUserDrinkRepository userDrinkRepository, ICocktailRepository cocktailRepository, IMapper mapper)
        {
            _repository = userDrinkRepository;
            _drinkRepository = cocktailRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Drink>> FavouriteDrink([FromBody] UserDrink userDrink)
        {
            try
            {
                _repository.FavouriteDrink(userDrink.UserId, userDrink.DrinkId);
                var favedDrink = await _drinkRepository.GetDrinkById(userDrink.DrinkId);
                return Ok(favedDrink);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        [Route("unFaveDrink")]
        public async Task<ActionResult<DrinkListItem>> UnFavouriteDrink([FromBody] UserDrink userDrink)
        {
            try
            {
                _repository.UnFavouriteDrink(userDrink.UserId, userDrink.DrinkId);
                var unFavedDrink =_mapper.Map<DrinkListItem>( await _drinkRepository.GetDrinkById(userDrink.DrinkId));
                return Ok(unFavedDrink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [Route("{userId}")]
        [HttpGet]
        public async Task<ActionResult<DrinkListItem[]>> GetUserDrinks(int userId)
        {
            try
            {
                var result = new List<DrinkListItem>();
                var drinkIds = await _repository.GetUserDrinks(userId);
                foreach (var drinkId in drinkIds)
                {
                    result.Add(_mapper.Map<DrinkListItem>(await _drinkRepository.GetDrinkById(drinkId)));
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
