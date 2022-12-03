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

        public PurchaseController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        // Filter by itemName and userId 
        [HttpGet("{itemName}/{userId}")]
        public async Task<PurchaseItem> GetPurchaseItem(string itemName, string userId) {
            return await _mongoDBService.GetAsyncPurchase(itemName, userId);
        }

        [HttpPost]
        public async Task<IActionResult> PostPurchaseItem([FromBody] PurchaseItem purchaseItem) {
            await _mongoDBService.CreateAsyncPurchase(purchaseItem);
            return CreatedAtAction(nameof(GetPurchaseItem), new { id = purchaseItem.ID }, purchaseItem);
        }

    }
}
