using AutoMapper;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Repository;

namespace SalesWeb.Server.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<List<DepartmentDto>>(departments);
        }
    }
}
