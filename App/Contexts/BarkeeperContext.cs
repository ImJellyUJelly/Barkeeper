using App.Models;
using MySql.Data.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace App.Contexts;

//[DbConfigurationType(typeof(MySqlEFConfiguration))]
[DbConfigurationType(typeof(Configuration))]
public class BarkeeperContext : DbContext
{
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderDetail>? OrderDetails { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Revenue>? Revenues { get; set; }

    //public BarkeeperContext() : base("Barkeeper_Development_MySql")
    //{
    //    Database.SetInitializer(new CreateDatabaseIfNotExists<BarkeeperContext>());
    //}

    public BarkeeperContext() : base(@";Server=localhost\SQLSERVER;Database=Barkeeper_Development;MultipleActiveResultSets=true;Integrated Security=true;Trusted_Connection=True;")
    {
        Database.SetInitializer(new CreateDatabaseIfNotExists<BarkeeperContext>());
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(order => order.Id);
        modelBuilder.Entity<Order>().Property(order => order.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<Order>().HasOptional(order => order.ParentOrder);
        modelBuilder.Entity<Order>().HasOptional(order => order.Customer);

        modelBuilder.Entity<Product>().HasKey(product => product.Id);
        modelBuilder.Entity<Product>().Property(product => product.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        modelBuilder.Entity<OrderDetail>().HasKey(od => od.Id);
        modelBuilder.Entity<OrderDetail>().Property(od => od.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<OrderDetail>().HasRequired(od => od.Product);
        modelBuilder.Entity<OrderDetail>().HasRequired(od => od.Order).WithMany(o => o.OrderDetails).WillCascadeOnDelete(true);

        modelBuilder.Entity<Customer>().HasKey(customer => customer.Id);
        modelBuilder.Entity<Customer>().Property(customer => customer.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    }
}

public class Configuration : DbConfiguration
{
    public Configuration()
    {
        SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(), "Barkeeper");
        SetDefaultConnectionFactory(new SqlConnectionFactory());
    }
}