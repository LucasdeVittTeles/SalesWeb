using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Data;
using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public class SalesRecordService : ISalesRecordService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public SalesRecordService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SalesRecordDto>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate != null)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate != null)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            var salesRecords = await result
                 .Include(x => x.Seller)
                 .Include(x => x.Seller.Department)
                 .OrderByDescending(x => x.Date)
                 .ToListAsync();


            return _mapper.Map<List<SalesRecordDto>>(salesRecords);
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
