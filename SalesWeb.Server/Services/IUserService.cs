using SalesWeb.Server.DTOs;

namespace SalesWeb.Server.Services.Exceptions
{
    public interface IUserService
    {
        Task InsertAsync(UserDto userDto);
        Task<bool> AuthenticateAsync(UserDto userDtod);
        Task<bool> UserExists(string username);
        public string GenerateToken(string username);
    }
}
