using AutoMapper;
using DrinksNet.Domain;
using DrinksNet.Domain.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace DrinksNet.AuxApi
{
    public class CocktailRepository :ICocktailRepository
    {
        private HttpClient _httpClient;
        private readonly IMapper _mapper;
        //TODO use IHttClientFactory

        public CocktailRepository(IMapper mapper)
        {
            _httpClient = new HttpClient();
            _mapper = mapper;
        }

        public async Task<IEnumerable<DrinkListItem>> GetDrinksByIngredient(string ingredient)
        {
            var url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={ingredient}";
            var response = await _httpClient.GetAsync(url);
            var toDeserialise = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DrinkListByIngredientRoot>(toDeserialise);
            var drinkListItemsDto = result.Drinks;
            var drinkItems = _mapper.Map<DrinkListItem[]>(drinkListItemsDto);

            return drinkItems;
        }

        public async Task<Drink> GetDrinkById(int id)
        {
            var url = $"http://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
            var response = await _httpClient.GetAsync(url);
            var toDeserialise = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<DrinkDetailsRoot>(toDeserialise);
            var drinkDetailsDto = result.Drinks.FirstOrDefault();
            var drinkDetails= _mapper.Map<Drink>(drinkDetailsDto);
            
            StructureDrink(drinkDetailsDto,drinkDetails);

            return drinkDetails;
        }

        private static void StructureDrink(DrinkDetailsResponseDto drinkDetailsDto, Drink drinkDetails)
        {
            for (var i = 1; i < 16; i++)
            {
                var ingredientName = "StrIngredient" + i;
                var tryGetIngredient = drinkDetailsDto.GetType().GetProperty(ingredientName)
                    .GetValue(drinkDetailsDto, null);
                if (tryGetIngredient != null)
                {
                    var ingredient = tryGetIngredient.ToString();
                    drinkDetails.Ingredients.Add(ingredient);
                }
            }
            for (var i = 1; i < 16; i++)
            {
                var measureName = "StrMeasure" + i;
                var tryGetMeasure = drinkDetailsDto.GetType().GetProperty(measureName)
                    .GetValue(drinkDetailsDto, null);
                if (tryGetMeasure != null)
                {
                    var measure = tryGetMeasure.ToString();
                    drinkDetails.Measures.Add(measure);
                }
            }
        }
    }
}
