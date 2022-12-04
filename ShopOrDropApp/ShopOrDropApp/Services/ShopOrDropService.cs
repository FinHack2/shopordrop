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

        public Task<float> GetPrediction(PurchaseItem item)
        {
            return _restService.GetPredictionAsync(item);
        }

        public Task<List<PurchaseItem>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }

        //public Task SaveTaskAsync(PurchaseItem item, bool isNewItem = false)
        public Task SaveTaskAsync(PurchaseItem item)
        {
            Debug.WriteLine(@"\t Clicked Save Button");
            //return _restService.SavePurchaseItemAsync(item, isNewItem);
            return _restService.SavePurchaseItemAsync(item);
        }


        //public Task DeleteTaskAsync(PurchaseItem item)
        //{
        //    return _restService.DeletePurchaseItemAsync(item.ID);
        //}
    }
}
