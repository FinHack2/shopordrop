using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace ShopOrDropAPI.Models
{
    public class UserInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [BsonElement("passwordHash")]
        [JsonPropertyName("passwordHash")]
        public string PasswordHash { get; set; } = null!;

        [BsonElement("age")]
        [JsonPropertyName("age")]
        public int Age { get; set; } = 0!;

        [BsonElement("gender")]
        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;

        [BsonElement("totalExpenditure")]
        [JsonPropertyName("totalExpenditure")]
        public string TotalExpenditure { get; set; } = null!;

    }

}
