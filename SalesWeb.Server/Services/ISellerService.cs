using SalesWeb.Server.DTOs;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public interface ISellerService
    {
        Task<List<SellerDto>> FindAllAsync();
        Task<SellerDto> FindByIdAsync(int id);
        Task InsertAsync(Seller seller);
        Task UpdateAsync(Seller seller);
        Task RemoveAsync(int id);
    }
}
