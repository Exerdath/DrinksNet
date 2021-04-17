using System.Collections.Generic;
using System.Threading.Tasks;
using DrinksNet.Domain;

namespace DrinksNet.AuxApi
{
    public interface ICocktailRepository
    {
        IEnumerable<Drink> GetDrinksByIngredient(string ingredient);
        Task<Drink> GetDrinksById(int id);

    }
}
