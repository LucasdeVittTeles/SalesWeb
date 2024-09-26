using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Server.Models;
using SalesWeb.Server.Services;

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
        public async Task<ActionResult> Register([FromBody] User user)
        {
            await _UserService.InsertAsync(user);
            return Ok();
        }
    }
}
