using SalesWeb.Server.Data;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Services
{
    public class SellerService
    {
        private readonly Context _context;

        public SellerService(Context context)
        {
            _context = context;
        }


        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }


        public Seller GetSellerById(int id)
        {
            return _context.Seller.FirstOrDefault(s => s.Id == id);
        }
    }
}
