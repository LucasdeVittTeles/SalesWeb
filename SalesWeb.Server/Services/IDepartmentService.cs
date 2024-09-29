using SalesWeb.Server.DTOs;

namespace SalesWeb.Server.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> FindAllAsync();
    }
}
