using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Services;

namespace SalesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }
    }
}
