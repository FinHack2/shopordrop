using System;
using Microsoft.AspNetCore.Mvc;
using ShopOrDropAPI.Services;
using ShopOrDropAPI.Models;

namespace ShopOrDropAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public class itemSearchQuery
        {
            public string itemName { get; set; } = null!;
            public string userId { get; set; } = null!;
        }

        public PurchaseController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        // Filter by itemName and userId 
        [HttpPost("search/")]
        public async Task<PurchaseItem> GetPurchaseItem([FromBody] itemSearchQuery query)
        {
            return await _mongoDBService.GetPurchaseItem(query.itemName, query.userId);
        }

        [ActionName("CreateAsyncPurchase")]
        [HttpPost]
        public async Task<PurchaseItem> PostPurchaseItem([FromBody] PurchaseItem purchaseItem) {
            await _mongoDBService.CreateAsyncPurchase(purchaseItem);
            return purchaseItem;
        }

    }
}
