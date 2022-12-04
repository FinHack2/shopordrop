namespace ShopOrDropApp.Models
{
    public class PurchaseItem
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public float ItemCost { get; set; }
        public string DayOfWeek { get; set; }
        public bool OnlinePurchase { get; set; }
    }
}
