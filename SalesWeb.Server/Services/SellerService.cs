using SalesWeb.Server.Data;
using SalesWeb.Server.Models;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Services.Exceptions;

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
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(s => s.Id == id);
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

        public void UpdateSeller(Seller seller)
        {
            if (!_context.Seller.Any(s => s.Id == seller.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
