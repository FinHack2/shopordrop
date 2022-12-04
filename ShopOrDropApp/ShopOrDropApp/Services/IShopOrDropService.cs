using ShopOrDropApp.Models;

namespace ShopOrDropApp.Services
{
    public interface IShopOrDropService
    {
        Task<List<PurchaseItem>> GetTasksAsync();
        Task SaveTaskAsync(PurchaseItem item, bool isNewItem);
        //Task DeleteTaskAsync(PurchaseItem item);
    }
}
