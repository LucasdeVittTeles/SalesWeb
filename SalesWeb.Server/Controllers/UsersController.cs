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

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
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
        public async Task<ActionResult> Login([FromBody] UserDto userDto)
        {

            var userExists = await _userService.UserExists(userDto.Username);

            if (!userExists)
            {
                return Unauthorized("Usuário não existe.");
            }

            var result = await _userService.AuthenticateAsync(userDto);

            if (!result)
            {
                return Unauthorized("Usuário ou senha inválido.");
            }

            var token = _userService.GenerateToken(userDto.Username);

            return Ok(new { Token = token });
        }
    }
}
