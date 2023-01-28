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
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Revenue> Revenues { get; set; }

    //public BarkeeperContext() : base("Barkeeper_Development_MySql")
    //{
    //    Database.SetInitializer(new CreateDatabaseIfNotExists<BarkeeperContext>());
    //    //Seed();
    //}

    public BarkeeperContext() : base(@"Server=DESKTOP-K6B8OF0\SQLEXPRESS;Database=Barkeeper_Development;MultipleActiveResultSets=true;Integrated Security=true;Trusted_Connection=True;")
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

    /// <summary>
    /// Seed the database with products.
    /// </summary>
    private void Seed()
    {
        // Warme Dranken
        Products.Add(new Product() { Name = "Koffie", Category = ProductCategory.Warme_Dranken, Price = 1.80M, MemberPrice = 1.20M });
        Products.Add(new Product() { Name = "Cappuccino", Category = ProductCategory.Warme_Dranken, Price = 2.10M, MemberPrice = 1.50M });
        Products.Add(new Product() { Name = "Café Crème", Category = ProductCategory.Warme_Dranken, Price = 1.80M, MemberPrice = 1.20M });
        Products.Add(new Product() { Name = "Espresso", Category = ProductCategory.Warme_Dranken, Price = 1.80M, MemberPrice = 1.20M });
        Products.Add(new Product() { Name = "Thee", Category = ProductCategory.Warme_Dranken, Price = 1.80M, MemberPrice = 1.20M });

        // Frisdranken
        Products.Add(new Product() { Name = "Appelsap", Category = ProductCategory.Frisdranken, Price = 2.40M, MemberPrice = 1.95M });
        Products.Add(new Product() { Name = "Bitter Lemon", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Cassis", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Chaudfontaine Blauw", Category = ProductCategory.Frisdranken, Price = 2.00M, MemberPrice = 1.60M });
        Products.Add(new Product() { Name = "Chaudfontaine Rood", Category = ProductCategory.Frisdranken, Price = 2.00M, MemberPrice = 1.60M });
        Products.Add(new Product() { Name = "Chocomel", Category = ProductCategory.Frisdranken, Price = 2.40M, MemberPrice = 1.95M });
        Products.Add(new Product() { Name = "Coca Cola", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Coca Cola Zero", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Fanta Orange", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Fuze Tea Green", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Fuze Tea Sparkling", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Jus d'Orange", Category = ProductCategory.Frisdranken, Price = 2.40M, MemberPrice = 1.95M });
        Products.Add(new Product() { Name = "Sprite", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });
        Products.Add(new Product() { Name = "Tonic", Category = ProductCategory.Frisdranken, Price = 2.20M, MemberPrice = 1.80M });

        // Wijnen
        Products.Add(new Product() { Name = "Rode Wijn", Category = ProductCategory.Wijnen, Price = 2.50M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Witte Wijn", Category = ProductCategory.Wijnen, Price = 2.50M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Rosé Wijn", Category = ProductCategory.Wijnen, Price = 2.50M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Flesje Wijn 25cl", Category = ProductCategory.Wijnen, Price = 5.00M, MemberPrice = 4.00M });
        Products.Add(new Product() { Name = "Port", Category = ProductCategory.Wijnen, Price = 2.50M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Sherry", Category = ProductCategory.Wijnen, Price = 2.50M, MemberPrice = 2.25M });

        // Bieren
        Products.Add(new Product() { Name = "Hertog Jan pilsener (tap)", Category = ProductCategory.Bieren, Price = 2.20M, MemberPrice = 1.95M });
        Products.Add(new Product() { Name = "Hertog Jan Pilsener (fles)", Category = ProductCategory.Bieren, Price = 2.40M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Hertog Jan 0.0 Pilsener", Category = ProductCategory.Bieren, Price = 2.40M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Hertog Jan Weizen", Category = ProductCategory.Bieren, Price = 2.40M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Leffe Blond", Category = ProductCategory.Bieren, Price = 2.80M, MemberPrice = 2.50M });
        Products.Add(new Product() { Name = "Leffe Bruin", Category = ProductCategory.Bieren, Price = 2.80M, MemberPrice = 2.50M });
        Products.Add(new Product() { Name = "Wieckse Rosé", Category = ProductCategory.Bieren, Price = 2.80M, MemberPrice = 2.50M });
        Products.Add(new Product() { Name = "Hoegaarden Radler 0.0", Category = ProductCategory.Bieren, Price = 2.40M, MemberPrice = 2.25M });

        // Gedestilleerd
        Products.Add(new Product() { Name = "Jenever", Category = ProductCategory.Gedestilleerd, Price = 2.40M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Schrobbelèr", Category = ProductCategory.Gedestilleerd, Price = 2.40M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Whisky", Category = ProductCategory.Gedestilleerd, Price = 2.40M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Vieux", Category = ProductCategory.Gedestilleerd, Price = 2.40M, MemberPrice = 2.25M });
        Products.Add(new Product() { Name = "Apfelkorn", Category = ProductCategory.Gedestilleerd, Price = 2.40M, MemberPrice = 2.25M });

        // Speciaal
        Products.Add(new Product() { Name = "Diverse Mixdranken", Category = ProductCategory.Specials, Price = 4.25M, MemberPrice = 3.95M });

        // Snacks
        Products.Add(new Product() { Name = "Kroket", Category = ProductCategory.Snacks, Price = 1.85M, MemberPrice = 1.50M });
        Products.Add(new Product() { Name = "Frikandel", Category = ProductCategory.Snacks, Price = 1.50M, MemberPrice = 1.35M });
        Products.Add(new Product() { Name = "Bitterballen (10st)", Category = ProductCategory.Snacks, Price = 6.50M, MemberPrice = 5.50M });
        Products.Add(new Product() { Name = "Minisnacks (10st)", Category = ProductCategory.Snacks, Price = 6.50M, MemberPrice = 5.50M });
        Products.Add(new Product() { Name = "Vegetarische snacks (10st)", Category = ProductCategory.Snacks, Price = 6.50M, MemberPrice = 5.50M });
        Products.Add(new Product() { Name = "Bitterballen (25st)", Category = ProductCategory.Snacks, Price = 12.00M, MemberPrice = 10.95M });
        Products.Add(new Product() { Name = "Minisnacks (25st)", Category = ProductCategory.Snacks, Price = 12.00M, MemberPrice = 10.95M });
        Products.Add(new Product() { Name = "Vegetarische snacks (25st)", Category = ProductCategory.Snacks, Price = 12.00M, MemberPrice = 10.95M });

        // Broodjes
        Products.Add(new Product() { Name = "Broodje Frikandel", Category = ProductCategory.Broodjes, Price = 1.90M, MemberPrice = 1.90M });
        Products.Add(new Product() { Name = "Broodje Kroket", Category = ProductCategory.Broodjes, Price = 2.10M, MemberPrice = 2.10M });
        Products.Add(new Product() { Name = "Broodje Ham", Category = ProductCategory.Broodjes, Price = 1.90M, MemberPrice = 1.90M });
        Products.Add(new Product() { Name = "Broodje Kaas", Category = ProductCategory.Broodjes, Price = 1.90M, MemberPrice = 1.90M });
        Products.Add(new Product() { Name = "Broodje Ham/Kaas", Category = ProductCategory.Broodjes, Price = 2.10M, MemberPrice = 2.10M });

        // Chips
        Products.Add(new Product() { Name = "Lays Naturel", Category = ProductCategory.Chips, Price = 1.00M, MemberPrice = 1.00M });
        Products.Add(new Product() { Name = "Dorito's", Category = ProductCategory.Chips, Price = 1.00M, MemberPrice = 1.00M });

        // Snoek en Koek
        Products.Add(new Product() { Name = "Mars", Category = ProductCategory.Snoep, Price = 1.00M, MemberPrice = 1.00M });
        Products.Add(new Product() { Name = "Snickers", Category = ProductCategory.Snoep, Price = 1.00M, MemberPrice = 1.00M });
        Products.Add(new Product() { Name = "Twix", Category = ProductCategory.Snoep, Price = 1.00M, MemberPrice = 1.00M });
        Products.Add(new Product() { Name = "Stroopwafels", Category = ProductCategory.Snoep, Price = 1.00M, MemberPrice = 1.00M });
        SaveChanges();
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

//public class Configuration : MySqlEFConfiguration
//{
//    public Configuration()
//    {
//        SetExecutionStrategy("MySql.Data.MySqlClient", () => new MySqlExecutionStrategy(), "Barkeeper");
//        SetDefaultConnectionFactory(new MySqlConnectionFactory());
//    }
//}