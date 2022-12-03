namespace ShopOrDropAPI.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionNamePurchases { get; set; } = null!;
        public string CollectionNameUsers { get; set; } = null!;
    }
}
