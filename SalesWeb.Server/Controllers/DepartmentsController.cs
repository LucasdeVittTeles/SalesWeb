using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly Context _context;

        public DepartmentsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Department.ToListAsync();
        }




        [HttpGet("{DepartmentId}")]

        public async Task<ActionResult<Department>> GetDepartmentForId(int departmentId)
        {
            Department department = await _context.Department.FindAsync(departmentId);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        [HttpPost]

        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            await _context.Department.AddAsync(department);
            await _context.SaveChangesAsync();

            return Ok();

       
        }

         /*

        [HttpDelete]
       
       
        public async Task<ActionResult> DeleteDepartment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        }
     */
        
    }
}
