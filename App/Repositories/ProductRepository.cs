using App.Contexts;
using App.Models;

namespace App.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly BarkeeperContext _context;

    // For testing only
    private readonly List<Product> _products;

    public ProductRepository(BarkeeperContext context)
    {
        _context = context;
        _products = new List<Product>() {
            new Product() { Id = 0, Name = "Koffie", MemberPrice = 1.40M, Price = 1.80M, Category = ProductCategory.Warme_Dranken },
            new Product() { Id = 1, Name = "Thee", MemberPrice = 1.40M, Price = 1.80M, Category = ProductCategory.Warme_Dranken },
            new Product() { Id = 2, Name = "Cappuccino", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Warme_Dranken },
            new Product() { Id = 3, Name = "Hertog-Jan", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Bieren },
            new Product() { Id = 4, Name = "Radler Alcoholvrij", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Bieren},
            new Product() { Id = 5, Name = "Rode Wijn", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Wijnen },
            new Product() { Id = 6, Name = "Witte Wijn", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Wijnen },
            new Product() { Id = 7, Name = "Chocomel", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Frisdranken },
            new Product() { Id = 8, Name = "Cola", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Frisdranken},
            new Product() { Id = 9, Name = "Cola Zero", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Frisdranken },
            new Product() { Id = 10, Name = "Fanta", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Frisdranken },
            new Product() { Id = 11, Name = "Sprite", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Frisdranken },
            new Product() { Id = 12, Name = "Pils Alcoholvrij", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Bieren },
            new Product() { Id = 13, Name = "Whiskey", MemberPrice = 2.00M, Price = 2.50M, Category = ProductCategory.Gedestilleerd },
            new Product() { Id = 14, Name = "Vodka", MemberPrice = 2.00M, Price = 2.50M, Category = ProductCategory.Gedestilleerd },
            new Product() { Id = 15, Name = "Fanta Zero", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Frisdranken },
            new Product() { Id = 16, Name = "Sprite Zero", MemberPrice = 1.80M, Price = 2.20M, Category = ProductCategory.Frisdranken },
            new Product() { Id = 17, Name = "Snickers", MemberPrice = 1.00M, Price = 1.10M, Category = ProductCategory.Snoep },
            new Product() { Id = 18, Name = "Mars", MemberPrice = 1.00M, Price = 1.10M, Category = ProductCategory.Snoep },
            new Product() { Id = 19, Name = "Frikandelletjes", MemberPrice = 2.00M, Price = 2.50M, Category = ProductCategory.Snacks },
            new Product() { Id = 20, Name = "Bitterballen", MemberPrice = 2.00M, Price = 2.50M, Category = ProductCategory.Snacks },
        };
    }

    public Product GetProductById(int productId)
    {
        return _products.FirstOrDefault(product => product.Id == productId);
    }

    public Product GetProductByName(string productName)
    {
        return _products.FirstOrDefault(product => product.Name == productName);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }
}
