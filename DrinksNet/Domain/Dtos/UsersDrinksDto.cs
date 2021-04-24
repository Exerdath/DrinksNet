using MongoDB.Bson;

namespace DrinksNet.Domain.Dtos
{
    public class UsersDrinksDto
    {
        public ObjectId Id { get; set; }
        public int userId { get; set; }
        public int drinkId { get; set; }
    }
}
