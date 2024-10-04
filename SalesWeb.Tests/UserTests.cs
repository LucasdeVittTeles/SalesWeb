using Moq;
using SalesWeb.Server.Models;
using SalesWeb.Server.Services;

namespace SalesWeb.Tests
{
    internal class UserTests
    {

        private readonly Mock<IUserService> _userServiceMock;
        private readonly AuthService _authService;

        public UserTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _authService = new AuthService(_userServiceMock.Object);
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var username = "test";
            var password = "test123";
            var user = new User { Username = username, PasswordHash = HashPassword(password) };

            _userServiceMock.Setup(x => x.UserExists(username).ReturnsAsync(user);

            // Act
            var token = await _authService.Login(username, password);

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
