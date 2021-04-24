using DrinksNet.Domain.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinksNet.DAL
{
    public class UserDrinksDataAccessLayer : DataAccessLayer, IDisposable
    {
        private string collectionName = "usersDrinks";

        public UserDrinksDataAccessLayer() : base()
        {
        }

        private IMongoCollection<UsersDrinksDto> GetUserDrinksCollection()
        {
            var userDrinksCollection = _database.GetCollection<UsersDrinksDto>(collectionName);
            return userDrinksCollection;
        }

        public async Task<IEnumerable<UsersDrinksDto>> GetAllUserDrinks()
        {
            try
            {
                var collection = GetUserDrinksCollection();
                return await collection.Find(new BsonDocument()).ToListAsync();
            }
            catch (MongoConnectionException)
            {
                return new List<UsersDrinksDto>();
            }
        }

        public async Task<List<int>> GetUserDrinks(int userId)
        {
            try
            {
                var collection = GetUserDrinksCollection();
                var builder = Builders<UsersDrinksDto>.Filter;
                var filter = builder.Eq("userId", userId);
                var userDrinks= await collection.Find(filter).ToListAsync();
                var listOfDrinks=new List<int>();
                foreach (var userDrinkDto in userDrinks)
                {
                    listOfDrinks.Add(userDrinkDto.drinkId);
                }

                return listOfDrinks;

            }
            catch (MongoConnectionException)
            {
                return new List<int>(){0};

            }
        }
    }
}
