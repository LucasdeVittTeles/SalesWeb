using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SalesWeb.Server.Data;
using SalesWeb.Server.Models;
using SalesWeb.Server.Services.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesWeb.Server.Services
{
    public class UserService : IUserService
    {
        private readonly Context _context;

        public UserService(Context context)
        {
            _context = context;
        }


        public async Task InsertAsync(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> validateLoginAsync(User user)
        {
            var existingUser = await _context.User.SingleOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(user.PasswordHash, existingUser.PasswordHash))
            {
                return false;
            }
            return true;
        }


        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua_chave_secreta"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
