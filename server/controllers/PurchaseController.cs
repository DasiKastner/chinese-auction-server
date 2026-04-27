using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.models;
using server.repositories;
using server.services;

namespace server.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> GetAllPurchasesBuUser(int id)
        {
            IEnumerable<object> purchases = await _purchaseService.GetPurchasesByUser(id);
            if (purchases != null)
                return Ok(purchases);
            return BadRequest(purchases); 
        }
        [HttpPost("{userId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> AddPurchase(int userId,[FromBody] int giftId)
        {
            var add = await _purchaseService.AddPurchase(userId, giftId);
            if (add != null)
                return Ok(add);
            return null;
        }
        [HttpDelete("{userId}/{giftId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> DeletePurchase(int userId, int giftId)
        {
            try
            {
                _purchaseService.DeletePurchase(userId, giftId);
                return Ok(new Purchase());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
            
        }
        [HttpPut("{userId}")]
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> BuyPurchase(int userId,[FromBody] int giftId)
        {
           await _purchaseService.updatePurchase(userId, giftId);
            return Ok(new Purchase());
        }
        [HttpGet("a/{giftId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetDetails(int giftId)
        {
            IEnumerable<User?> users = await _purchaseService.GetDetails(giftId);
            if(users.Any())
            {
                return Ok(users);
            }
            return BadRequest("can't get users");
        }
        [HttpGet("getDetails")]
        [Authorize(Roles = "admin")]
        public async Task<IEnumerable<object>>? GetDetails()
        {
            return await _purchaseService.GetAllDetails();
        }
    }
}
