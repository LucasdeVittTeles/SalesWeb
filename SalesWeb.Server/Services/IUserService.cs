using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public interface IUserService
    {
        Task InsertAsync(UserDto userDto);
        Task<bool> AuthenticateAsync(UserDto userDtod);
        Task<User> UserExists(string username);
        public string GenerateToken(string username);
    }
}
