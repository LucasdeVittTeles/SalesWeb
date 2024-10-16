using SalesWeb.Server.Models;

namespace SalesWeb.Server.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
    }
}
