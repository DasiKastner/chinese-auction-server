using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.models;

using server.services;

namespace server.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }
        [HttpGet]
        public IActionResult getAllGift()
        {
            Console.WriteLine("qqqqqqqqqqqqqqqqqqqqqqqqqqq");
            IEnumerable<GiftDTO> gifts = _giftService.getAllGift();
            if (gifts != null)
                return Ok(gifts);
            return BadRequest(gifts);
        }
        [HttpGet("{id}")]
        [Authorize(Roles ="admin")]
        public IActionResult getGiftById(int id)
        {
            var gift = _giftService.getGiftById(id);
            if (gift != null)
                return Ok(gift);
            return BadRequest(gift);
        }
        [HttpPost]
        [Authorize(Roles = "admin,user")]
        public IActionResult createGift([FromBody] GiftDTO gift)
        {
            GiftDTO? newgift = _giftService.createGift(gift);
            if (newgift != null)
                return Ok(newgift);
            return BadRequest(newgift);
        }
        [HttpPut]
        [Authorize(Roles = "admin,user")]
        public IActionResult updateGift([FromBody]GiftDTO gift)
        {
            GiftDTO? updateGift = _giftService.updateGift(gift);
            if (updateGift != null)
                return Ok(updateGift);
            return BadRequest(updateGift);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,user")]
        public void deleteGift(int id)
        {
            Console.WriteLine("wwwwwwww");
            _giftService.deleteGift(id);
            //return Ok("fgvdfbgd");
            //_giftService.getAllGift()
        }
        [HttpGet("/nameGift")]
        public Gift? GetGiftByName([FromQuery] string giftName)
        {
            return _giftService.GetGiftByName(giftName);
        }
        [HttpGet("/nameDonor")]
        public List<Gift> GetGiftsByDonor(string donorName)
        {
            return _giftService.GetGiftsByDonor(donorName);
        }
    }
}
