using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace ShopOrDropAPI.Models
{
    public class PurchaseItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }

        [BsonElement("itemName")]
        [JsonPropertyName("itemName")]
        public string ItemName { get; set; } = null!;

        [BsonElement("userId")]
        [JsonPropertyName("userId")]
        public string UserID { get; set; } = null!;

        [BsonElement("category")]
        [JsonPropertyName("category")]
        public string Category { get; set; } = null!;

        [BsonElement("itemCost")]
        [JsonPropertyName("itemCost")]
        public float ItemCost { get; set; } = 0!;

        [BsonElement("dayOfWeek")]
        [JsonPropertyName("dayOfWeek")]
        public string DayOfWeek { get; set; } = null!;

        [BsonElement("onlinePurchase")]
        [JsonPropertyName("onlinePurchase")]
        public bool OnlinePuchase { get; set; } = false;

        [BsonElement("satisfaction")]
        [JsonPropertyName("satisfaction")]
        public float Satisfaction { get; set; } = 0!;
    } 
}