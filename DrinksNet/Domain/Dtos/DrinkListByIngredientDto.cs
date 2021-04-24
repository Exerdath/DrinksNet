using System.Collections.Generic;

namespace DrinksNet.Domain.Dtos
{
    public class DrinkListByIngredientDto
    {
        public string StrDrink { get; set; }
        public string StrDrinkThumb { get; set; }
        public string IdDrink { get; set; }
    }

    public class DrinkListByIngredientRoot
    {
        public List<DrinkListByIngredientDto> Drinks { get; set; }
    }
}
