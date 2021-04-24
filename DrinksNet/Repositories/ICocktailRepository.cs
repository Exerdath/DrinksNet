using System.Collections.Generic;
using System.Threading.Tasks;
using DrinksNet.Domain;

namespace DrinksNet.AuxApi
{
    public interface ICocktailRepository
    {
        Task<IEnumerable<DrinkListItem>> GetDrinksByIngredient(string ingredient);
        Task<Drink> GetDrinkById(int id);

    }
}
