using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Repository
{
    public class SellerRepository : ISellerRepository
    {


        private readonly Context _context;

        public SellerRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seller>> GetAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> GetByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task AddAsync(Seller seller)
        {
            await _context.Seller.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var seller = await GetByIdAsync(id);
            if (seller != null)
            {
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            _context.Entry(seller).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
