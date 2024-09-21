using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SalesWeb.Server.Models;
using SalesWeb.Server.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserService _UserService;

        public UsersController(UserService userService)
        {
            _UserService = userService;
        }


        [HttpPost("Register")]
        public ActionResult Register([FromBody] User user)
        {
            _UserService.InsertUser(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, existingUser.PasswordHash))
                return Unauthorized();
            var token = GenerateJwtToken(existingUser.Username);
            return Ok(new { Token = token });
        }
    }
}
