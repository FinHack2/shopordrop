using ShopOrDropAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ShopOrDropAPI.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<PurchaseItem> _purchasesCollection;
        private readonly IMongoCollection<UserInfo> _usersCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {

            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _purchasesCollection = database.GetCollection<PurchaseItem>(mongoDBSettings.Value.CollectionNamePurchases);
            _usersCollection = database.GetCollection<UserInfo>(mongoDBSettings.Value.CollectionNameUsers);
        }


        public async Task<PurchaseItem> GetAsyncPurchase(string itemName, string userId) {
            // Filter by itemName and userId 
            var filter = Builders<PurchaseItem>.Filter.Eq("itemName", itemName) & Builders<PurchaseItem>.Filter.Eq("userId", userId);
            return await _purchasesCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task CreateAsyncPurchase(PurchaseItem purchaseItem) {
            // Create a new purchase item
            await _purchasesCollection.InsertOneAsync(purchaseItem);
        }


        // TODO: Add callsto db for users database
        public async Task<UserInfo> GetUserByEmail(string email)
        {
            var filter =  Builders<UserInfo>.Filter.Eq("email", email);
            return await _usersCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task CreateAsyncUser(UserInfo userInfo)
        {

            // Create a new user
            await _usersCollection.InsertOneAsync(userInfo);
        }

    }
}
