using AutoMapper;
using Moq;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;
using SalesWeb.Server.Repository;
using SalesWeb.Server.Services;

namespace SalesWeb.Tests
{
    public class SellerServiceTests
    {

        private readonly Mock<ISellerRepository> _sellerRepositoryMock;
        private readonly IMapper _mapper;
        private readonly ISellerService _sellerService;

        public SellerServiceTests()
        {
            _sellerRepositoryMock = new Mock<ISellerRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<SellerDto, Seller>().ReverseMap();
            });
            _mapper = mappingConfig.CreateMapper();
            _sellerService = new SellerService(_sellerRepositoryMock.Object, _mapper);
        }


        [Fact]
        //Given_When_Then
        public async Task GetSellers_ReturnsAllSellers()
        {
            //arrange
            var sellers = new List<Seller>
            {
                new Seller { Id = 1, Name = "Teste", Email = "string",BirthDate = DateTime.Now, BaseSalary = 20.0, DepartmentId = 1 },
                new Seller { Id = 2, Name = "Teste2", Email = "string2",BirthDate = DateTime.Now, BaseSalary = 30.0, DepartmentId = 2 },
            };

            _sellerRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(sellers);

            //act
            var result = await _sellerService.GetAllAsync();
            var otherSellers = _mapper.Map<List<Seller>>(result);

            Assert.Equivalent(sellers, otherSellers);
        }

        [Fact]
        public async Task GetByIdAsync_ExistingId_ReturnsProduto()
        {
            // Arrange
            var seller = new Seller { Id = 1, Name = "Teste", Email = "string", BirthDate = DateTime.Now, BaseSalary = 20.0, DepartmentId = 1 };
            _sellerRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(seller);

            // Act
            var result = await _sellerService.GetByIdAsync(1);
            var otherSeller = _mapper.Map<Seller>(result);

            Assert.Equivalent(seller, otherSeller);
        }

        [Fact]
        public async Task CreateAsync_ValidProduto_AddsProduto()
        {
            // Arrange
            var seller = new Seller { Id = 1, Name = "Teste", Email = "string", BirthDate = DateTime.Now, BaseSalary = 20.0, DepartmentId = 1 };
            _sellerRepositoryMock.Setup(repo => repo.AddAsync(seller));
            var otherSeller = _mapper.Map<SellerDto>(seller);


            // Act
            await _sellerService.AddAsync(otherSeller);

            // Assert
            _sellerRepositoryMock.Verify(repo => repo.AddAsync(seller), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ValidProduto_UpdatesProduto()
        {
            // Arrange
            var seller = new Seller { Id = 1, Name = "Teste", Email = "string", BirthDate = DateTime.Now, BaseSalary = 20.0, DepartmentId = 1 };
            var otherSeller = _mapper.Map<SellerDto>(seller);

            // Act
            await _sellerService.UpdateAsync(otherSeller);

            // Assert
            _sellerRepositoryMock.Verify(repo => repo.UpdateAsync(seller), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ExistingId_DeletesProduto()
        {
            // Arrange
            var id = 1;

            // Act
            await _sellerService.DeleteAsync(id);

            // Assert
            _sellerRepositoryMock.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }

        /*
        [Fact]
        public async Task AdicionarAsync_Quando_Houver_Erro_Deve_Lancar_Excecao()
        {
            var produto = new Produto { Id = 1, Nome = "Produto 1", Preco = 10.0m };
            _mockRepository.Setup(r => r.AdicionarAsync(produto)).ThrowsAsync(new Exception("Erro ao adicionar produto"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.AdicionarAsync(produto));
            Assert.Equal("Erro ao adicionar produto", exception.Message);
        }
        */

    }
}