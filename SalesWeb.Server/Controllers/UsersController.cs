using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Services;

namespace SalesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] UserDto userDto)
        {

            if (userDto == null)
            {
                return BadRequest("Dados inválidos");
            }

            var userExists = await _userService.UserExists(userDto.Username);

            if (userExists)
            {
                return BadRequest("Este username já possui um cadastro.");
            }

            await _userService.InsertAsync(userDto);
            return Ok();
        }


        [HttpPost("login")]
        public Task<ActionResult> Login([FromBody] UserDto userDto)
        {
            return Ok();
        }
    }
}
