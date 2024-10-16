using SalesWeb.Server.Models;

namespace SalesWeb.Server.Data
{
    public class SeedingService
    {
        private readonly Context _context;

        public SeedingService(Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any() || _context.User.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.SaveChanges();
        }
    }
}
