using Domain.Models.Administrators;
using Domain.Models.Customers;
using Domain.Models.DairyExchange;
using Domain.Models.Login;
using Domain.Models.MilkDeliveries;
using Domain.Models.Stores;
using Microsoft.EntityFrameworkCore;

namespace Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Admin> Administrators { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MilkStore> MilkStores { get; set; }
        public DbSet<MilkDelivery> MilkDelivery { get; set; }
        public DbSet<DairyExchange> DajiryExchange { get; set;}

    }
}
