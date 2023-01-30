namespace App.Migrations
{
    using App.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<App.Contexts.BarkeeperContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(App.Contexts.BarkeeperContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            ////  to avoid creating duplicate seed data.

            //// Warme Dranken
            //context.Products.AddOrUpdate(new Product() { Name = "Koffie", Category = ProductCategory.Warme_Dranken, Price = 1.80M, EventPrice = 1.20M });
            //context.Products.AddOrUpdate(new Product() { Name = "Cappuccino", Category = ProductCategory.Warme_Dranken, Price = 2.10M, EventPrice = 1.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Café Crème", Category = ProductCategory.Warme_Dranken, Price = 1.80M, EventPrice = 1.20M });
            //context.Products.AddOrUpdate(new Product() { Name = "Espresso", Category = ProductCategory.Warme_Dranken, Price = 1.80M, EventPrice = 1.20M });
            //context.Products.AddOrUpdate(new Product() { Name = "Thee", Category = ProductCategory.Warme_Dranken, Price = 1.80M, EventPrice = 1.20M });

            //// Frisdranken
            //context.Products.AddOrUpdate(new Product() { Name = "Appelsap", Category = ProductCategory.Frisdranken, Price = 2.40M, EventPrice = 1.95M });
            //context.Products.AddOrUpdate(new Product() { Name = "Bitter Lemon", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Cassis", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Chaudfontaine Blauw", Category = ProductCategory.Frisdranken, Price = 2.00M, EventPrice = 1.60M });
            //context.Products.AddOrUpdate(new Product() { Name = "Chaudfontaine Rood", Category = ProductCategory.Frisdranken, Price = 2.00M, EventPrice = 1.60M });
            //context.Products.AddOrUpdate(new Product() { Name = "Chocomel", Category = ProductCategory.Frisdranken, Price = 2.40M, EventPrice = 1.95M });
            //context.Products.AddOrUpdate(new Product() { Name = "Coca Cola", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Coca Cola Zero", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Fanta Orange", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Fuze Tea Green", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Fuze Tea Sparkling", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Jus d'Orange", Category = ProductCategory.Frisdranken, Price = 2.40M, EventPrice = 1.95M });
            //context.Products.AddOrUpdate(new Product() { Name = "Sprite", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });
            //context.Products.AddOrUpdate(new Product() { Name = "Tonic", Category = ProductCategory.Frisdranken, Price = 2.20M, EventPrice = 1.80M });

            //// Wijnen
            //context.Products.AddOrUpdate(new Product() { Name = "Rode Wijn", Category = ProductCategory.Wijnen, Price = 2.50M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Witte Wijn", Category = ProductCategory.Wijnen, Price = 2.50M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Rosé Wijn", Category = ProductCategory.Wijnen, Price = 2.50M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Flesje Wijn 25cl", Category = ProductCategory.Wijnen, Price = 5.00M, EventPrice = 4.00M });
            //context.Products.AddOrUpdate(new Product() { Name = "Port", Category = ProductCategory.Wijnen, Price = 2.50M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Sherry", Category = ProductCategory.Wijnen, Price = 2.50M, EventPrice = 2.25M });

            //// Bieren
            //context.Products.AddOrUpdate(new Product() { Name = "Hertog Jan pilsener (tap)", Category = ProductCategory.Bieren, Price = 2.20M, EventPrice = 1.95M });
            //context.Products.AddOrUpdate(new Product() { Name = "Hertog Jan Pilsener (fles)", Category = ProductCategory.Bieren, Price = 2.40M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Hertog Jan 0.0 Pilsener", Category = ProductCategory.Bieren, Price = 2.40M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Hertog Jan Weizen", Category = ProductCategory.Bieren, Price = 2.40M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Leffe Blond", Category = ProductCategory.Bieren, Price = 2.80M, EventPrice = 2.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Leffe Bruin", Category = ProductCategory.Bieren, Price = 2.80M, EventPrice = 2.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Wieckse Rosé", Category = ProductCategory.Bieren, Price = 2.80M, EventPrice = 2.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Hoegaarden Radler 0.0", Category = ProductCategory.Bieren, Price = 2.40M, EventPrice = 2.25M });

            //// Gedestilleerd
            //context.Products.AddOrUpdate(new Product() { Name = "Jenever", Category = ProductCategory.Gedestilleerd, Price = 2.40M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Schrobbelèr", Category = ProductCategory.Gedestilleerd, Price = 2.40M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Whisky", Category = ProductCategory.Gedestilleerd, Price = 2.40M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Vieux", Category = ProductCategory.Gedestilleerd, Price = 2.40M, EventPrice = 2.25M });
            //context.Products.AddOrUpdate(new Product() { Name = "Apfelkorn", Category = ProductCategory.Gedestilleerd, Price = 2.40M, EventPrice = 2.25M });

            //// Speciaal
            //context.Products.AddOrUpdate(new Product() { Name = "Diverse Mixdranken", Category = ProductCategory.Specials, Price = 4.25M, EventPrice = 3.95M });

            //// Snacks
            //context.Products.AddOrUpdate(new Product() { Name = "Kroket", Category = ProductCategory.Snacks, Price = 1.85M, EventPrice = 1.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Frikandel", Category = ProductCategory.Snacks, Price = 1.50M, EventPrice = 1.35M });
            //context.Products.AddOrUpdate(new Product() { Name = "Bitterballen (10st)", Category = ProductCategory.Snacks, Price = 6.50M, EventPrice = 5.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Minisnacks (10st)", Category = ProductCategory.Snacks, Price = 6.50M, EventPrice = 5.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Vegetarische snacks (10st)", Category = ProductCategory.Snacks, Price = 6.50M, EventPrice = 5.50M });
            //context.Products.AddOrUpdate(new Product() { Name = "Bitterballen (25st)", Category = ProductCategory.Snacks, Price = 12.00M, EventPrice = 10.95M });
            //context.Products.AddOrUpdate(new Product() { Name = "Minisnacks (25st)", Category = ProductCategory.Snacks, Price = 12.00M, EventPrice = 10.95M });
            //context.Products.AddOrUpdate(new Product() { Name = "Vegetarische snacks (25st)", Category = ProductCategory.Snacks, Price = 12.00M, EventPrice = 10.95M });

            //// Broodjes
            //context.Products.AddOrUpdate(new Product() { Name = "Broodje Frikandel", Category = ProductCategory.Broodjes, Price = 1.90M, EventPrice = 1.90M });
            //context.Products.AddOrUpdate(new Product() { Name = "Broodje Kroket", Category = ProductCategory.Broodjes, Price = 2.10M, EventPrice = 2.10M });
            //context.Products.AddOrUpdate(new Product() { Name = "Broodje Ham", Category = ProductCategory.Broodjes, Price = 1.90M, EventPrice = 1.90M });
            //context.Products.AddOrUpdate(new Product() { Name = "Broodje Kaas", Category = ProductCategory.Broodjes, Price = 1.90M, EventPrice = 1.90M });
            //context.Products.AddOrUpdate(new Product() { Name = "Broodje Ham/Kaas", Category = ProductCategory.Broodjes, Price = 2.10M, EventPrice = 2.10M });

            //// Chips
            //context.Products.AddOrUpdate(new Product() { Name = "Lays Naturel", Category = ProductCategory.Chips, Price = 1.00M, EventPrice = 1.00M });
            //context.Products.AddOrUpdate(new Product() { Name = "Dorito's", Category = ProductCategory.Chips, Price = 1.00M, EventPrice = 1.00M });

            //// Snoek en Koek
            //context.Products.AddOrUpdate(new Product() { Name = "Mars", Category = ProductCategory.Snoep, Price = 1.00M, EventPrice = 1.00M });
            //context.Products.AddOrUpdate(new Product() { Name = "Snickers", Category = ProductCategory.Snoep, Price = 1.00M, EventPrice = 1.00M });
            //context.Products.AddOrUpdate(new Product() { Name = "Twix", Category = ProductCategory.Snoep, Price = 1.00M, EventPrice = 1.00M });
            //context.Products.AddOrUpdate(new Product() { Name = "Stroopwafels", Category = ProductCategory.Snoep, Price = 1.00M, EventPrice = 1.00M });
        }
    }
}
