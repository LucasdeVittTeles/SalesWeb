using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.DTOs;

namespace SalesWeb.Server.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;

        public DepartmentService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> FindAllAsync()
        {
            var departments = await _context.Department.OrderBy(d => d.Name).ToListAsync();
            return _mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
