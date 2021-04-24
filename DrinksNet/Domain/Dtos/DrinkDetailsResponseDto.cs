using System.Collections.Generic;

namespace DrinksNet.Domain.Dtos
{
    public class DrinkDetailsResponseDto
    {
        public string IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrInstructions { get; set; }
        public string StrDrinkThumb { get; set; }
        public string StrIngredient1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public object StrIngredient5 { get; set; }
        public object StrIngredient6 { get; set; }
        public object StrIngredient7 { get; set; }
        public object StrIngredient8 { get; set; }
        public object StrIngredient9 { get; set; }
        public object StrIngredient10 { get; set; }
        public object StrIngredient11 { get; set; }
        public object StrIngredient12 { get; set; }
        public object StrIngredient13 { get; set; }
        public object StrIngredient14 { get; set; }
        public object StrIngredient15 { get; set; }
        public string StrMeasure1 { get; set; }
        public string StrMeasure2 { get; set; }
        public string StrMeasure3 { get; set; }
        public object StrMeasure4 { get; set; }
        public object StrMeasure5 { get; set; }
        public object StrMeasure6 { get; set; }
        public object StrMeasure7 { get; set; }
        public object StrMeasure8 { get; set; }
        public object StrMeasure9 { get; set; }
        public object StrMeasure10 { get; set; }
        public object StrMeasure11 { get; set; }
        public object StrMeasure12 { get; set; }
        public object StrMeasure13 { get; set; }
        public object StrMeasure14 { get; set; }
        public object StrMeasure15 { get; set; }
    }

    public class DrinkDetailsRoot
    {
        public List<DrinkDetailsResponseDto> Drinks { get; set; }
    }

}
