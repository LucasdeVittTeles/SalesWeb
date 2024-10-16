using SalesWeb.Server.Models;

namespace SalesWeb.Server.Repository
{
    public interface ISalesRecordRepository
    {
        Task<List<SalesRecord>> GetAllAsync();
        Task<List<SalesRecord>> GetByDateAsync(DateTime minDate, DateTime maxDate);
        Task<List<IGrouping<Department, SalesRecord>>> GetByDateGroupingAsync(DateTime minDate, DateTime maxDate);
    }
}
