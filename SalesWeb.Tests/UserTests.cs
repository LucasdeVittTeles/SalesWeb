using Moq;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;
using SalesWeb.Server.Services;

namespace SalesWeb.Tests
{
    internal class UserTests
    {

        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserService _userService;

        public UserTests(UserService userService)
        {
            _userServiceMock = new Mock<IUserService>();
            _userService = userService;
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var userDto = new UserDto()
            {
                Id = 0,
                Username = "test",
                PasswordHash = "test123"
            }; 

            _userServiceMock.Setup(x => x.UserExists(userDto.Username)).Returns();

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
    }
}
