using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class SolfOrbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        public DbSet<Provider> Providers { get; set; } = null!;

        public SolfOrbContext(DbContextOptions<SolfOrbContext> options)
            : base(options)
        { }
    }
}
