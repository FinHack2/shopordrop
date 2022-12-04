using ShopOrDropApp.Models;

namespace ShopOrDropApp.Services
{
    public interface IShopOrDropService
    {
        Task<List<PurchaseItem>> GetTasksAsync();
        Task SaveTaskAsync(PurchaseItem item);
        //Task DeleteTaskAsync(PurchaseItem item);

        Task<float> GetPrediction(PurchaseItem item);
    }
}
