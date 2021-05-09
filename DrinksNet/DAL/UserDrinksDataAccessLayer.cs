using DrinksNet.Domain.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinksNet.DAL
{
    public class UserDrinksDataAccessLayer : DataAccessLayer, IDisposable, IUserDrinksDataAccessLayer
    {
        private string collectionName = "usersDrinks";

        public UserDrinksDataAccessLayer() : base()
        {
        }

        private IMongoCollection<UserDrinkDto> GetUserDrinksCollection()
        {
            var userDrinksCollection = _database.GetCollection<UserDrinkDto>(collectionName);
            return userDrinksCollection;
        }

        public async Task<IEnumerable<UserDrinkDto>> GetAllUserDrinks()
        {
            try
            {
                var collection = GetUserDrinksCollection();
                return await collection.Find(new BsonDocument()).ToListAsync();
            }
            catch (MongoConnectionException)
            {
                return new List<UserDrinkDto>();
            }
        }

        public async Task<int[]> GetUserDrinks(int userId)
        {
            try
            {
                var collection = GetUserDrinksCollection();
                var builder = Builders<UserDrinkDto>.Filter;
                var filter = builder.Eq("userId", userId);
                var userDrinks = await collection.Find(filter).ToListAsync();
                var listOfDrinks = new List<int>();
                foreach (var userDrinkDto in userDrinks)
                {
                    listOfDrinks.Add(userDrinkDto.drinkId);
                }

                var restul=listOfDrinks.ToArray();

                return restul;

            }
            catch (MongoConnectionException)
            {
                return new int[] {0};

            }
        }

        public async void AddDrinkToUser(int userId, int drinkId)
        {
            try
            {
                var collection = GetUserDrinksCollection();
                var builder = Builders<UserDrinkDto>.Filter;
                var filter = builder.Eq("userId", userId) & builder.Eq("drinkId", drinkId);
                var userDrinks = await collection.Find(filter).ToListAsync();
                if (userDrinks.Count==0)
                {
                    await collection.InsertOneAsync(new UserDrinkDto()
                    {
                        userId = userId,
                        drinkId = drinkId
                    });
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async void RemoveDrinkFromUser(int userId, int drinkId)
        {
            try
            {
                var collection = GetUserDrinksCollection();
                var builder = Builders<UserDrinkDto>.Filter;
                var filter = builder.Eq("userId", userId) & builder.Eq("drinkId", drinkId);
                var userDrinks = await collection.Find(filter).FirstOrDefaultAsync();
                if (userDrinks != null)
                {
                    filter = builder.Empty;
                    filter = builder.Eq("_id", userDrinks.Id);
                    await collection.DeleteOneAsync(filter);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
