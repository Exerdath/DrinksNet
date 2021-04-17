using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DrinksNet.Domain;

namespace DrinksNet.AuxApi
{
    public class CocktailRepository :ICocktailRepository
    {
        private HttpClient _httpClient;
        //TODO use IHttClientFactory

        public CocktailRepository()
        {
            _httpClient = new HttpClient();
        }

        public IEnumerable<Drink> GetDrinksByIngredient(string ingredient)
        {
            throw new NotImplementedException();
        }

        public async Task<Drink> GetDrinksById(int id)
        {
            var url = "http://www.thecocktaildb.com/api/json/v1/1/lookup.php?iid=552";
            var response = await _httpClient.GetAsync(url);
            var result = response.Content.ReadAsStringAsync().Result;

            return null;
        }
    }
}
