using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.Models;
using SalesWeb.Server.Repository.Exeptions;

namespace SalesWeb.Server.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            var checkUser = await _context.User.AnyAsync(u => u.Id == user.Id);

            if (checkUser)
            {
                throw new UserExistsException("usuario já cadastrado.");
            }

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> VerifyUsernameAsync(string username)
        {
            return await _context.User.SingleOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }
    }
}
