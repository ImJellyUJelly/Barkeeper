using Models;
using System.Data.Entity;

namespace API.Contexts;

public class BarkeeperContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Product { get; set; }

    public BarkeeperContext(): base("Host=localhost;Database=Barkeeper_Development;Port=5432;User ID=root;Password=Password01!") 
    {
        Database.SetInitializer(new CreateDatabaseIfNotExists<BarkeeperContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(order => order.Id);

        modelBuilder.Entity<Product>().HasKey(product => product.Id);

        modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
    }
}
