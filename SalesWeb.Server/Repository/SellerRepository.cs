using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.Models;
using SalesWeb.Server.Repository.Exeptions;

namespace SalesWeb.Server.Repository
{
    public class SellerRepository : ISellerRepository
    {


        private readonly Context _context;

        public SellerRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Seller>> GetAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task<Seller> GetByIdAsync(int id)
        {
            var seller = await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
            if (seller == null)
            {
                throw new SellerNotFoundException("Vendedor não encontrado na base de dados");
            }
            return seller;
        }

        public async Task AddAsync(Seller seller)
        {
            await _context.Seller.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var seller = await GetByIdAsync(id);
            if (seller == null)
            {
                throw new SellerNotFoundException("Vendedor não encontrado na base de dados.");
            }
            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            _context.Entry(seller).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
