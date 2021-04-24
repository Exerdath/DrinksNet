using DrinksNet.AuxApi;
using DrinksNet.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DrinksNet.Controllers
{
    [Route("{controller}")]
    public class DrinksController : Controller
    {
        private ICocktailRepository _drinksRepository;

        public DrinksController(ICocktailRepository repository)
        {
            _drinksRepository = repository;
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<Drink>> Get(int id)
        {
            var check = await _drinksRepository.GetDrinkById(id);
            return Ok(check);
        }

        [Route("drinksByIng/{ingredient}")]
        [HttpGet]
        public async Task<ActionResult<Drink>> GetByIng(string ingredient)
        {
            var check = await _drinksRepository.GetDrinksByIngredient(ingredient);
            return Ok(check);
        }
    }
}
