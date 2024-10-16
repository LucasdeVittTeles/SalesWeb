using SalesWeb.Server.Models;

namespace SalesWeb.Server.Repository
{
    public interface ISellerRepository
    {
        Task<List<Seller>> GetAllAsync();
        Task<Seller> GetByIdAsync(int id);
        Task AddAsync(Seller seller);
        Task UpdateAsync(Seller seller);
        Task DeleteAsync(int id);
    }
}
