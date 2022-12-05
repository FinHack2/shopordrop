using System.Text.Json.Serialization;

namespace ShopOrDropAPI.Models
{
    public class PredictionResult
    {
        [JsonPropertyName("dayOfWeek")]
        public List<int> DayOfWeek { get; set; } = new List<int>();

        [JsonPropertyName("category")]
        public List<int> Category { get; set; } = new List<int>();

        [JsonPropertyName("itemCost")]
        public float ItemCost { get; set; } = 0!;

        [JsonPropertyName("satisfaction")]
        public float Satisfaction { get; set; } = 0!;

        [JsonPropertyName("online")]
        public int OnlinePuchase { get; set; } = 0!; 

        [JsonPropertyName("features")]
        public List<float> Features { get; set; } = new List<float>();


        [JsonPropertyName("score")]
        public float Score { get; set; } = 0!;

    }
}
