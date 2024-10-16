using SalesWeb.Server.Models;

namespace SalesWeb.Server.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> VerifyUsernameAsync(string username);
    }
}
