using System.Collections.Generic;

namespace DrinksNet.Domain
{
    public class Drink
    {
        public int IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrInstructions { get; set; }
        public string StrThumb { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public IEnumerable<string> Measures { get; set; }
        public string Path { get; set; }
    }
}
