using System.Collections.Generic;

namespace DrinksNet.Domain
{
    public class Drink
    {
        public int IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrInstructions { get; set; }
        public string StrDrinkThumb { get; set; }
        public IList<string> Ingredients { get; set; } = new List<string>();
        public IList<string> Measures { get; set; } = new List<string>();
        public string Path { get; set; }
    }
}
