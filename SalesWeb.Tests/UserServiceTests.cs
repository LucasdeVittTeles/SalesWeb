using AutoMapper;
using Castle.Core.Configuration;
using Moq;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;
using SalesWeb.Server.Repository;
using SalesWeb.Server.Services;

namespace SalesWeb.Tests
{
    internal class UserServiceTests
    {

        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        /*
        public UserServiceTests(IConfiguration configuration)
        {
            _configuration = configuration;
            _userRepositoryMock = new Mock<IUserRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<SellerDto, Seller>().ReverseMap();
            });
            _mapper = mappingConfig.CreateMapper();
            _userService = new UserService(_userRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var user = new User()
            {
                Id = 0,
                Username = "test",
                PasswordHash = "test123"
            }; 

            _userRepositoryMock.Setup(x => x.UserExists(user)).Returns();

            // Act
            var token = await _userService.AuthenticateAsync();

            // Assert
            Assert.NotNull(token);
            Assert.True(token.Length > 0);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsNull()
        {
            // Arrange
            var username = "testuser";
            var password = "wrongpassword";

            _userServiceMock.Setup(x => x.ValidateUser(username, password)).ReturnsAsync((User)null);

            // Act
            var token = await _authService.Login(username, password);

            // Assert
            Assert.Null(token);
        }

        private string HashPassword(string password)
        {
            // Implemente sua lógica de hash de senha aqui
            return password; // Apenas para exemplo; nunca use senhas em texto puro.
        }
        */
    }
}
