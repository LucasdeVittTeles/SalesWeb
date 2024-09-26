using SalesWeb.Server.DTOs;

namespace SalesWeb.Server.Services
{
    public interface ISellerService
    {
        Task<List<SellerDto>> FindAllAsync();
        Task<SellerDto> FindByIdAsync(int id);
        Task InsertAsync(SellerDto sellerDto);
        Task UpdateAsync(SellerDto sellerDto);
        Task RemoveAsync(int id);
    }
}
