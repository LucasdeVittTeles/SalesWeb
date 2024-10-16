using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Repository
{
    public class SalesRecordRepository : ISalesRecordRepository
    {

        private readonly Context _context;

        public SalesRecordRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> GetAllAsync()
        {
            return await _context.SalesRecord.ToListAsync();
        }

        public async Task<List<SalesRecord>> GetByDateAsync(DateTime minDate, DateTime maxDate)
        {
            return await _context.SalesRecord.Where(sr => sr.Date >= minDate && sr.Date <= maxDate).ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> GetByDateGroupingAsync(DateTime minDate, DateTime maxDate)
        {
            return await _context.SalesRecord.Where(sr => sr.Date >= minDate && sr.Date <= maxDate)
            .Include(sr => sr.Seller)
            .Include(sr => sr.Seller.Department)
            .OrderByDescending(sr => sr.Date)
            .GroupBy(sr => sr.Seller.Department)
            .ToListAsync();
        }
    }
}
