using FoodOrdering.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrdering.DAL.Date
{
    public class FoodOrderingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2MCESAJ\\SQLEXPRESS;Initial Catalog=TestFoodOrderingDB;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
    }
}
