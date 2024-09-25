using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> FindAllAsync();
    }
}
