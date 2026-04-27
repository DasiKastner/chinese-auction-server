using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.models;
using server.services;

namespace server.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtTokenService _jwtTokenService;
        public AuthController(IUserService userService, JwtTokenService jwtTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllUsers()
        {
            IEnumerable<User> users = await _userService.getAllUsers();
            if (users.Any() || users != null)
                return Ok(users);
            return BadRequest("cannot get users");
        }
        [HttpPost]      
        public async Task<IActionResult> Register([FromBody]User user)
        {
            User? user1 = await _userService.createUser(user);
            return Ok(user);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
                User? user =await _userService.login(loginDTO.UserName, loginDTO.Password);
            if (user != null)
                {
                    Console.WriteLine("yeeeee");
                    var token = _jwtTokenService.GenerateJwtToken(user);
                    return Ok(new { Token = token , role = user.Role == "admin"});

                }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
    }
}
