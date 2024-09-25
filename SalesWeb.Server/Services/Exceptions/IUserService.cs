using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services.Exceptions
{
    public interface IUserService
    {
        Task InsertAsync(User user);
        Task<bool> validateLoginAsync(User user);
    }
}
