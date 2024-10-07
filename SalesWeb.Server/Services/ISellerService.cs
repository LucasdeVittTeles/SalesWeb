using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;
using System.Threading.Tasks;

namespace SalesWeb.Server.Services
{
    public interface ISellerService
    {
        Task<IEnumerable<SellerDto>> GetAllAsync();
        Task<SellerDto> GetByIdAsync(int id);
        Task AddAsync(SellerDto sellerDto);
        Task UpdateAsync(SellerDto sellerDto);
        Task DeleteAsync(int id);
    }
}
