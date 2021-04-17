using System.Threading.Tasks;
using DrinksNet.AuxApi;
using DrinksNet.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DrinksNet.Controllers
{
    [Route("api/{controller}")]
    public class DrinksController: Controller
    {
        private ICocktailRepository _drinksRepository;

        public DrinksController(ICocktailRepository repository)
        {
            _drinksRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Drink>> Get()
        {
            var check = _drinksRepository.GetDrinksById(1);
            return Ok("alabala");
        }

    }
}
