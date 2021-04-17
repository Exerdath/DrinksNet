using MongoDB.Bson;

namespace DrinksNet.Domain
{
    public class UserDrink
    {
        public ObjectId Id { get; set; }
        public int UserId { get; set; }
        public int DrinkId { get; set; }

    }
}
