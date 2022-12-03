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

        [ActionName("CreateAsyncUser")]
        [HttpPost]
        public async Task<UserInfo> PostUserInfo([FromBody] UserInfo userInfo)
        {
            await _mongoDBService.CreateAsyncUser(userInfo);

            return userInfo;
        }

    }
}
