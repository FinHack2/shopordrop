using System;
using Microsoft.AspNetCore.Mvc;
using ShopOrDropAPI.Services;
using ShopOrDropAPI.Models;

namespace ShopOrDropAPI.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly MongoDBService _mongoDBService;

        public UserController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }


        [HttpGet("{email}")]
        public async Task<UserInfo> GetUserInfo(string email) 
        {
            // Get the user with that email search single document
            return await _mongoDBService.GetUserByEmail(email);
        }

        [HttpPost]
        public async Task<IActionResult> PostUserInfo([FromBody] UserInfo userInfo)
        {
            await _mongoDBService.CreateAsyncUser(userInfo);
            return CreatedAtAction(nameof(GetUserInfo), new { id = userInfo.ID }, userInfo);
        }

    }
}
