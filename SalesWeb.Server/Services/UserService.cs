using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SalesWeb.Server.Data;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesWeb.Server.Services
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(Context context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task InsertAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> AuthenticateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var storedUser = await _context.User.SingleOrDefaultAsync(u => u.Username.ToLower() == user.Username.ToLower());

            if (storedUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, storedUser.PasswordHash))
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UserExists(string username)
        {
            var storedUser = await _context.User.SingleOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            if (storedUser == null)
            {
                return false;
            }
            return true;
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
