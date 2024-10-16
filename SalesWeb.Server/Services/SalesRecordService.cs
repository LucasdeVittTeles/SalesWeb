using SalesWeb.Server.Models;
using SalesWeb.Server.Repository;

namespace SalesWeb.Server.Services
{
    public class SalesRecordService : ISalesRecordService
    {
        private readonly ISalesRecordRepository _salesRecordRepository;

        public SalesRecordService(ISalesRecordRepository salesRecordRepository)
        {
            _salesRecordRepository = salesRecordRepository;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime minDate, DateTime maxDate)
        {
            return await _salesRecordRepository.GetByDateAsync(minDate, maxDate);
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime minDate, DateTime maxDate)
        {
            return await _salesRecordRepository.GetByDateGroupingAsync(minDate, maxDate);
        }
    }
}
