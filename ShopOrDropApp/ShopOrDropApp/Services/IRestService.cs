using ShopOrDropApp.Models;

namespace ShopOrDropApp.Services
{
    public interface IRestService
    {
        Task<List<PurchaseItem>> RefreshDataAsync();

        Task SavePurchaseItemAsync(PurchaseItem item, bool isNewItem);

        //Task DeletePurchaseItemAsync(string id);
    }
}
