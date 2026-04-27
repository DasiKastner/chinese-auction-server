using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.models;
using server.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        public readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult getAllDonors()
        {
            return Ok(_donorService.getAllDonors());
        }
        [HttpGet("a/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult getDonorById(int id)
        {
            Donor? donor = _donorService.getDonorById(id);
            if(donor!=null)
                return Ok(donor);
            return BadRequest("id did'nt found");
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult createDonor([FromBody]Donor donor)
        {
            Donor donor1 = _donorService.createDonor(donor);
            if (donor1 != null)
                return Ok(donor1);
            return BadRequest("fail to create donor");
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        public IActionResult updateDonor([FromBody] Donor donor)
        {
            Donor? newDonor = _donorService.updateDonor(donor);
            if (newDonor != null)
                return Ok(newDonor);
            return BadRequest("can't update donor");
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void deleteDonor(int id)
        {
           _donorService.deleteDonor(id);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult getDonorGifts(int id)
        {
            
            List<GiftDTO?> gifts = _donorService.getDonorGifts(id);
            if (gifts.Any())
                return Ok(gifts);
            return BadRequest("can't get the gifts");
        }
    }
}
