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


        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }


        public void RemoveSeller(int id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
    }
}
