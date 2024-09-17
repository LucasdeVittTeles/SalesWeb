using SalesWeb.Server.Data;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public class DepartmentService
    {

        private readonly Context _context;

        public DepartmentService(Context context)
        {
            _context = context;
        }

        public List<Department> FindAllDepartments()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }


    }
}
