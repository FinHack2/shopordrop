using System.Diagnostics;
using System.Text;
using System.Text.Json;
using ShopOrDropApp.Models;

namespace ShopOrDropApp.Services
{
    public class RestService : IRestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        IHttpsClientHandlerService _httpsClientHandlerService;

        public List<PurchaseItem> Items { get; private set; }

        public RestService(IHttpsClientHandlerService service)
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<PurchaseItem>> RefreshDataAsync()
        {
            Items = new List<PurchaseItem>();

            // https://localhost:7237/api/Purchase/searchMany with POST
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Purchase/searchMany"));
            // Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                // search by user id
                var json = JsonSerializer.Serialize(new { 
                    userId = "638b0176ec0cf7776b91d3f7"
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //// add headers
                //_client.DefaultRequestHeaders.Add("content-type", "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tRetrieved purchase items successfully.");

                    var contentString = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<PurchaseItem>>(contentString, _serializerOptions);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SavePurchaseItemAsync(PurchaseItem item)
        {
            // https://localhost:7237/api/Purchase/add with POST
            Uri uri = new Uri(string.Format(Constants.RestUrl, "Purchase/add"));
            //Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            Debug.WriteLine(@"\t Uri {0}", string.Format(Constants.RestUrl, "Purchase/add"));
            try
            {

                //string json = JsonSerializer.Serialize<PurchaseItem>(item, _serializerOptions);
                var json = JsonSerializer.Serialize(new
                {
                    id = "",
                    userId = "638b0176ec0cf7776b91d3f7",
                    itemName = item.ItemName,
                    category = item.Category,
                    itemCost = item.ItemCost,
                    dayOfWeek = "sun",
                    onlinePurchase = item.OnlinePurchase
                });
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                Debug.WriteLine(@"\t Content {0}", json.ToString());

                //// add headers
                //content.Headers.Add("content-type", "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tPurchaseItem successfully saved.");
                } else
                {
                    Debug.WriteLine(@"\t ERROR {0}", response.ToString());

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        //public async Task DeletePurchaseItemAsync(string id)
        //{
        //    Uri uri = new Uri(string.Format(Constants.RestUrl, id));

        //    try
        //    {
        //        HttpResponseMessage response = await _client.DeleteAsync(uri);
        //        if (response.IsSuccessStatusCode)
        //            Debug.WriteLine(@"\tPurchaseItem successfully deleted.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }
        //}
    }
}
