using System;
using Microsoft.AspNetCore.Mvc;
using ShopOrDropAPI.Services;
using ShopOrDropAPI.Models;

namespace ShopOrDropAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public class itemSearchQuery
        {
            public string itemName { get; set; } = null!;
            public string userId { get; set; } = null!;
        }

        public class itemManySearchQuery
        {
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

        // Filter by itemName and userId 
        [HttpPost("searchMany/")]
        public async Task<List<PurchaseItem>> GetManyPurchaseItem([FromBody] itemManySearchQuery query)
        {
            return await _mongoDBService.GetManyPurchaseItem(query.userId);
        }

        [ActionName("CreateAsyncPurchase")]
        [HttpPost("add/")]
        public async Task<PurchaseItem> PostPurchaseItem([FromBody] PurchaseItem purchaseItem) {
            await _mongoDBService.CreateAsyncPurchase(purchaseItem);
            return purchaseItem;
        }

    }
}
