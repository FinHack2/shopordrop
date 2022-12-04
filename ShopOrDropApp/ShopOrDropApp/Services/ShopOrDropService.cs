using ShopOrDropApp.Models;
using System.Diagnostics;

namespace ShopOrDropApp.Services
{
    public class ShopOrDropService : IShopOrDropService
    {
        IRestService _restService;

        public ShopOrDropService(IRestService service)
        {
            _restService = service;
        }

        public Task<List<PurchaseItem>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(PurchaseItem item, bool isNewItem = false)
        {
            Debug.WriteLine(@"\t Clicked Save Button");
            return _restService.SavePurchaseItemAsync(item, isNewItem);
        }

        //public Task DeleteTaskAsync(PurchaseItem item)
        //{
        //    return _restService.DeletePurchaseItemAsync(item.ID);
        //}
    }
}
