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
    public DbSet<Session> Sessions { get; set; }
    public DbSet<GeneralOptions> GeneralOptions { get; set; }

    //public BarkeeperContext() : base("Barkeeper_Development_MySql")
    //{
    //    Database.SetInitializer(new CreateDatabaseIfNotExists<BarkeeperContext>());
    //    //Seed();
    //}

    public BarkeeperContext() : base(@"Server=DESKTOP-K6B8OF0\SQLEXPRESS;Database=Barkeeper_Development;MultipleActiveResultSets=true;Integrated Security=true;Trusted_Connection=True;")
    {
        Database.SetInitializer(new CreateDatabaseIfNotExists<BarkeeperContext>());
        //Seed();
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

        modelBuilder.Entity<Session>().HasKey(session => session.Id);
        modelBuilder.Entity<Session>().Property(session => session.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<Session>().Property(session => session.EndDate).IsOptional();

        modelBuilder.Entity<GeneralOptions>().HasKey(option => option.Id);
    }

    /// <summary>
    /// Seed the database with products.
    /// </summary>
    private void Seed()
    {
        // Warme Dranken
        Products.Add(new Product() { Name = "Koffie", Category = ProductCategory.Warme_Dranken, EventPrice = 1.80M, Price = 1.20M, IsActive = true });
        Products.Add(new Product() { Name = "Cappuccino", Category = ProductCategory.Warme_Dranken, EventPrice = 2.10M, Price = 1.50M, IsActive = true });
        Products.Add(new Product() { Name = "Café Crème", Category = ProductCategory.Warme_Dranken, EventPrice = 1.80M, Price = 1.20M, IsActive = true });
        Products.Add(new Product() { Name = "Espresso", Category = ProductCategory.Warme_Dranken, EventPrice = 1.80M, Price = 1.20M, IsActive = true });
        Products.Add(new Product() { Name = "Thee", Category = ProductCategory.Warme_Dranken, EventPrice = 1.80M, Price = 1.20M, IsActive = true });

        // Frisdranken
        Products.Add(new Product() { Name = "Appelsap", Category = ProductCategory.Frisdranken, EventPrice = 2.40M, Price = 1.95M, IsActive = true });
        Products.Add(new Product() { Name = "Bitter Lemon", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Cassis", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Chaudfontaine Blauw", Category = ProductCategory.Frisdranken, EventPrice = 2.00M, Price = 1.60M, IsActive = true });
        Products.Add(new Product() { Name = "Chaudfontaine Rood", Category = ProductCategory.Frisdranken, EventPrice = 2.00M, Price = 1.60M, IsActive = true });
        Products.Add(new Product() { Name = "Chocomel", Category = ProductCategory.Frisdranken, EventPrice = 2.40M, Price = 1.95M, IsActive = true });
        Products.Add(new Product() { Name = "Coca Cola", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Coca Cola Zero", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Fanta Orange", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Fuze Tea Green", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Fuze Tea Sparkling", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Jus d'Orange", Category = ProductCategory.Frisdranken, EventPrice = 2.40M, Price = 1.95M, IsActive = true });
        Products.Add(new Product() { Name = "Sprite", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });
        Products.Add(new Product() { Name = "Tonic", Category = ProductCategory.Frisdranken, EventPrice = 2.20M, Price = 1.80M, IsActive = true });

        // Wijnen
        Products.Add(new Product() { Name = "Rode Wijn", Category = ProductCategory.Wijnen, EventPrice = 2.50M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Witte Wijn", Category = ProductCategory.Wijnen, EventPrice = 2.50M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Rosé Wijn", Category = ProductCategory.Wijnen, EventPrice = 2.50M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Flesje Wijn 25cl", Category = ProductCategory.Wijnen, EventPrice = 5.00M, Price = 4.00M, IsActive = true });
        Products.Add(new Product() { Name = "Port", Category = ProductCategory.Wijnen, EventPrice = 2.50M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Sherry", Category = ProductCategory.Wijnen, EventPrice = 2.50M, Price = 2.25M, IsActive = true });

        // Bieren
        Products.Add(new Product() { Name = "Hertog Jan pilsener (tap)", Category = ProductCategory.Bieren, EventPrice = 2.20M, Price = 1.95M, IsActive = true });
        Products.Add(new Product() { Name = "Hertog Jan Pilsener (fles)", Category = ProductCategory.Bieren, EventPrice = 2.40M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Hertog Jan 0.0 Pilsener", Category = ProductCategory.Bieren, EventPrice = 2.40M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Hertog Jan Weizen", Category = ProductCategory.Bieren, EventPrice = 2.40M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Leffe Blond", Category = ProductCategory.Bieren, EventPrice = 2.80M, Price = 2.50M, IsActive = true });
        Products.Add(new Product() { Name = "Leffe Bruin", Category = ProductCategory.Bieren, EventPrice = 2.80M, Price = 2.50M, IsActive = true });
        Products.Add(new Product() { Name = "Wieckse Rosé", Category = ProductCategory.Bieren, EventPrice = 2.80M, Price = 2.50M, IsActive = true });
        Products.Add(new Product() { Name = "Hoegaarden Radler 0.0", Category = ProductCategory.Bieren, EventPrice = 2.40M, Price = 2.25M, IsActive = true });

        // Gedestilleerd
        Products.Add(new Product() { Name = "JeEventPriceer", Category = ProductCategory.Gedestilleerd, EventPrice = 2.40M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Schrobbelèr", Category = ProductCategory.Gedestilleerd, EventPrice = 2.40M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Whisky", Category = ProductCategory.Gedestilleerd, EventPrice = 2.40M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Vieux", Category = ProductCategory.Gedestilleerd, EventPrice = 2.40M, Price = 2.25M, IsActive = true });
        Products.Add(new Product() { Name = "Apfelkorn", Category = ProductCategory.Gedestilleerd, EventPrice = 2.40M, Price = 2.25M, IsActive = true });

        // Speciaal
        Products.Add(new Product() { Name = "Diverse Mixdranken", Category = ProductCategory.Specials, EventPrice = 4.25M, Price = 3.95M, IsActive = true });

        // Snacks
        Products.Add(new Product() { Name = "Kroket", Category = ProductCategory.Snacks, EventPrice = 1.85M, Price = 1.50M, IsActive = true });
        Products.Add(new Product() { Name = "Frikandel", Category = ProductCategory.Snacks, EventPrice = 1.50M, Price = 1.35M, IsActive = true });
        Products.Add(new Product() { Name = "Bitterballen (10st)", Category = ProductCategory.Snacks, EventPrice = 6.50M, Price = 5.50M, IsActive = true });
        Products.Add(new Product() { Name = "Minisnacks (10st)", Category = ProductCategory.Snacks, EventPrice = 6.50M, Price = 5.50M, IsActive = true });
        Products.Add(new Product() { Name = "Vegetarische snacks (10st)", Category = ProductCategory.Snacks, EventPrice = 6.50M, Price = 5.50M, IsActive = true });
        Products.Add(new Product() { Name = "Bitterballen (25st)", Category = ProductCategory.Snacks, EventPrice = 12.00M, Price = 10.95M, IsActive = true });
        Products.Add(new Product() { Name = "Minisnacks (25st)", Category = ProductCategory.Snacks, EventPrice = 12.00M, Price = 10.95M, IsActive = true });
        Products.Add(new Product() { Name = "Vegetarische snacks (25st)", Category = ProductCategory.Snacks, EventPrice = 12.00M, Price = 10.95M, IsActive = true });

        // Broodjes
        Products.Add(new Product() { Name = "Broodje Frikandel", Category = ProductCategory.Broodjes, EventPrice = 1.90M, Price = 1.90M, IsActive = true });
        Products.Add(new Product() { Name = "Broodje Kroket", Category = ProductCategory.Broodjes, EventPrice = 2.10M, Price = 2.10M, IsActive = true });
        Products.Add(new Product() { Name = "Broodje Ham", Category = ProductCategory.Broodjes, EventPrice = 1.90M, Price = 1.90M, IsActive = true });
        Products.Add(new Product() { Name = "Broodje Kaas", Category = ProductCategory.Broodjes, EventPrice = 1.90M, Price = 1.90M, IsActive = true });
        Products.Add(new Product() { Name = "Broodje Ham/Kaas", Category = ProductCategory.Broodjes, EventPrice = 2.10M, Price = 2.10M, IsActive = true });

        // Chips
        Products.Add(new Product() { Name = "Lays Naturel", Category = ProductCategory.Chips, EventPrice = 1.00M, Price = 1.00M, IsActive = true });
        Products.Add(new Product() { Name = "Dorito's", Category = ProductCategory.Chips, EventPrice = 1.00M, Price = 1.00M, IsActive = true });

        // Snoek en Koek
        Products.Add(new Product() { Name = "Mars", Category = ProductCategory.Snoep, EventPrice = 1.00M, Price = 1.00M, IsActive = true });
        Products.Add(new Product() { Name = "Snickers", Category = ProductCategory.Snoep, EventPrice = 1.00M, Price = 1.00M, IsActive = true });
        Products.Add(new Product() { Name = "Twix", Category = ProductCategory.Snoep, EventPrice = 1.00M, Price = 1.00M, IsActive = true });
        Products.Add(new Product() { Name = "Stroopwafels", Category = ProductCategory.Snoep, EventPrice = 1.00M, Price = 1.00M, IsActive = true });
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