using MongoDB.Bson;

namespace DrinksNet.AuxApi.Dtos
{
    public class UserDto
    {
        public ObjectId Id { get; set; }
        public int userId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
