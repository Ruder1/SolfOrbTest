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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var listProviders = new List<Provider>
            {
                new Provider 
                {
                    Id=1,
                    Name="Швеи"
                },
                new Provider 
                {
                    Id=2,
                    Name="Завод"
                },
                new Provider
                {
                    Id=3,
                    Name = "Магазин"
                },
                new Provider
                {
                    Id =4,
                    Name ="Офис"
                }
            };

            var listOrders = new List<Order>
            {
                new Order
                {
                    Id=1,
                    Number ="#125321423",
                    ProviderId = 1,
                    Date =  DateOnly.Parse( DateTime.Now.Date.ToString("d"))
                },
                new Order
                {
                    Id = 2,
                    Number ="#125425324",
                    ProviderId = 4,
                    Date =  DateOnly.Parse( DateTime.Now.Date.ToString("d"))
                },
                new Order
                {
                    Id = 3,
                    Number ="#654634523",
                    ProviderId = 3,
                    Date =  DateOnly.Parse( DateTime.Now.Date.ToString("d"))
                },
                new Order
                {
                    Id = 4,
                    Number ="#6512357671",
                    ProviderId = 2,
                    Date = DateOnly.Parse( DateTime.Now.Date.ToString("d"))
                }
            };

            var listOrderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    Id=1,
                    Name = "Вилка",
                    OrderId = 1,
                    Quantity = 123.43m,
                    Unit = "Что то"
                },
                new OrderItem
                {
                    Id=2,
                    Name = "Ложка",
                    OrderId = 2,
                    Quantity = 5123.43m,
                    Unit = "Что то"
                },
                new OrderItem
                {
                    Id=3,
                    Name = "Мебель",
                    OrderId = 3,
                    Quantity = 1135.43m,
                    Unit = "Что то"
                },
                new OrderItem
                {
                    Id=4,
                    Name = "Ресурс",
                    OrderId = 4,
                    Quantity = 4563.43m,
                    Unit = "Что то"
                }
            };

            modelBuilder.Entity<OrderItem>().HasData(listOrderItems);
            modelBuilder.Entity<Order>().HasData(listOrders);
            modelBuilder.Entity<Provider>().HasData(listProviders);

            modelBuilder
                .Entity<Order>()
                .HasOne(p => p.Provider)
                .WithMany(o => o.Order)
                .HasForeignKey(o => o.ProviderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(i => i.OrderItem);
        }
    }
}
