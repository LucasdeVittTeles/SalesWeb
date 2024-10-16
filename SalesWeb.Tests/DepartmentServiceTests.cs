using AutoMapper;
using Moq;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;
using SalesWeb.Server.Repository;
using SalesWeb.Server.Services;

namespace SalesWeb.Tests
{
    public class DepartmentServiceTests
    {
        private readonly Mock<IDepartmentRepository> _departmentRepositoryMock;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public DepartmentServiceTests()
        {
            _departmentRepositoryMock = new Mock<IDepartmentRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Department, DepartmentDto>().ReverseMap();
            });
            _mapper = mappingConfig.CreateMapper();
            _departmentService = new DepartmentService(_departmentRepositoryMock.Object, _mapper);
        }


        [Fact]
        //Given_When_Then
        public async Task GetDepartments_ReturnsAllDepartments()
        {
            //arrange
            var departments = new List<Department>
            {
                new Department { Id = 1, Name = "Teste1"},
                new Department { Id = 2, Name = "Teste2"},
            };

            _departmentRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(departments);

            //act
            var result = await _departmentService.GetAllAsync();
            var otherDepartments = _mapper.Map<List<Department>>(result);

            //Assert
            Assert.Equivalent(departments, otherDepartments);
        }
    }
}
