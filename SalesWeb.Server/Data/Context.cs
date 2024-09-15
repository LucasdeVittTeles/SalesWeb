using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Data
{
    public class Context : DbContext
    {
        public DbSet<Department> Department { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
