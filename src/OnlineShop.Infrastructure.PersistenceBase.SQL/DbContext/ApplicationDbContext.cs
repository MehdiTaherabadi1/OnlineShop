using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Infrastructure.PersistenceBase.SQL.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}
