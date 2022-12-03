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

        public class userSearchQuery
        {
            public string email { get; set; } = null!;
        }

        public UserController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpPost("search/")]
        public async Task<UserInfo> GetUserInfo([FromBody] userSearchQuery query) 
        {
            // Get the user with that email search single document
            return await _mongoDBService.GetUserByEmail(query.email);
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
