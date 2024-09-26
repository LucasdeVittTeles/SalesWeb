using SalesWeb.Server.Data;
using SalesWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Services.Exceptions;
using AutoMapper;
using SalesWeb.Server.DTOs;

namespace SalesWeb.Server.Services
{
    public class SellerService : ISellerService
    {

        private readonly Context _context;
        private readonly IMapper _mapper;

        public SellerService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<SellerDto>> FindAllAsync()
        {
            var sellers = await _context.Seller.ToListAsync();
            return _mapper.Map<List<SellerDto>>(sellers);
        }


        public async Task<SellerDto> FindByIdAsync(int id)
        {
            var seller = await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
            return _mapper.Map<SellerDto>(seller);
        }


        public async Task InsertAsync(Seller seller)
        {
            await _context.AddAsync(seller);
            await _context.SaveChangesAsync();
        }


        public async Task RemoveAsync(int id)
        {
            try
            {
                var seller = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller seller)
        {

            bool hasAny = await _context.Seller.AnyAsync(s => s.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
