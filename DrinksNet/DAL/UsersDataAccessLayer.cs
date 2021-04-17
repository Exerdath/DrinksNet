using DrinksNet.AuxApi.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinksNet.DAL
{
    public class UsersDataAccessLayer: DataAccessLayer, IDisposable
    {
        private string collectionName = "users";

        public UsersDataAccessLayer():base()
        {
        }

        private IMongoCollection<UserDto> GetUsersCollection()
        {
            var usersCollection = _database.GetCollection<UserDto>(collectionName);
            return usersCollection;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            try
            {
                var collection = GetUsersCollection();
                return await collection.Find(new BsonDocument()).ToListAsync();
            }
            catch (MongoConnectionException)
            {
                return new List<UserDto>();
            }
        }

        public async Task<UserDto> GetUserForLogin(string email,string password)
        {
            try
            {
                var collection = GetUsersCollection();
                var builder = Builders<UserDto>.Filter;
                var filter = builder.Eq("email", email) & builder.Eq("password", password);
                return await collection.Find(filter).Limit(1).SingleAsync();
                 
            }
            catch (MongoConnectionException)
            {
                return new UserDto();

            }
        }

    }
}
