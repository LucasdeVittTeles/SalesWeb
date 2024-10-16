using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly Context _context;

        public DepartmentRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Department.ToListAsync();
        }
    }
}
