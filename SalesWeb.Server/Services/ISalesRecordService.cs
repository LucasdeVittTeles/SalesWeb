using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public interface ISalesRecordService
    {
        Task<List<SalesRecord>> FindByDateAsync(DateTime minDate, DateTime maxDate);
        Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime minDate, DateTime maxDate);
    }
}
