using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;
using SalesWeb.Server.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesWeb.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task InsertAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _userRepository.AddAsync(user);
        }

        public async Task<bool> AuthenticateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var storedUser = await _userRepository.VerifyUsernameAsync(user.Username);

            if (storedUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, storedUser.PasswordHash))
            {
                return false;
            }
            return true;
        }

        public async Task<User> UserExists(string username)
        {
            var storedUser = await _userRepository.VerifyUsernameAsync(username);
            return storedUser;
        }

        public string GenerateToken(string username)
        {
            var claims = new[]
              {
              new Claim(JwtRegisteredClaimNames.Sub, username),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
          };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
