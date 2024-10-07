using Microsoft.EntityFrameworkCore;
using SalesWeb.Server.Models;

namespace SalesWeb.Server.Data
{
    public class Context : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<User> User { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seller>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Sellers)
                .HasForeignKey(s => s.DepartmentId);
        }
    }
}
