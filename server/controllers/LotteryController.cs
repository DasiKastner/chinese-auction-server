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
    [Authorize(Roles = "admin")]
    public class LotteryController : ControllerBase
    {
        private readonly ILotteryService _lotteryService;
        public LotteryController(ILotteryService lotteryService)
        {
            _lotteryService = lotteryService;
        }
        [HttpGet]
        public async Task<IActionResult> getWinners()
        {
            IEnumerable<LotteryDTO> winners = await _lotteryService.getWinners();
            if (winners != null)
                return Ok(winners);
            return BadRequest("failed to get winners");
        }
        [HttpPost]
        public async Task<IActionResult> drow([FromBody]int giftId)
        {
            User? user = await _lotteryService.drow(giftId);
            if (user != null)
                return Ok(user);
            return BadRequest(user);
        }
        [HttpGet("totalPay")]
        public async Task<IActionResult> totalPay()
        {
            int benefits = await _lotteryService.totalPay();
            if (benefits != -1)
                return Ok(benefits);
            return BadRequest(benefits);
        }
    }
}
