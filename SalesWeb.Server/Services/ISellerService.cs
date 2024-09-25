using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public interface ISellerService
    {
        Task<List<Seller>> FindAllAsync();
        Task<Seller> FindByIdAsync(int id);
        Task InsertAsync(Seller seller);
        Task UpdateAsync(Seller seller);
        Task RemoveAsync(int id);
    }
}
