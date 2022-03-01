using App.Models;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace App.Contexts;

[DbConfigurationType(typeof(MySqlEFConfiguration))]
public class BarkeeperContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public BarkeeperContext(): base("server=localhost;port=3306;database=Barkeeper_Development;uid=root;password=Password01!")
    {
        Database.SetInitializer(new CreateDatabaseIfNotExists<BarkeeperContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(order => order.Id);
        modelBuilder.Entity<Order>().HasOptional(order => order.ParentOrder);

        modelBuilder.Entity<Product>().HasKey(product => product.Id);

        modelBuilder.Entity<OrderDetail>().HasKey(od => od.Id);
        modelBuilder.Entity<OrderDetail>().HasRequired(od => od.Product);
        modelBuilder.Entity<OrderDetail>().HasRequired(od => od.Order).WithMany(o => o.OrderDetails).WillCascadeOnDelete(false);
    }
}
