using Flurl;
using Models;

namespace App.Agents;

public class ProductAgent : IProductAgent
{
    private readonly List<Product> _products;
    private readonly Url _url;

    public ProductAgent()
    {
        _products = new List<Product>() {
            new Product() { Id = 0, Name = "Koffie", MemberPrice = 1.40M, Price = 1.80M },
            new Product() { Id = 1, Name = "Thee", MemberPrice = 1.40M, Price = 1.80M },
            new Product() { Id = 2, Name = "Cappuccino", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 3, Name = "Hertog-Jan", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 4, Name = "Radler Alcoholvrij", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 5, Name = "Rode Wijn", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 6, Name = "Witte Wijn", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 7, Name = "Chocomel", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 8, Name = "Cola", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 9, Name = "Cola Zero", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 10, Name = "Fanta", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 11, Name = "Sprite", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 12, Name = "Pils Alcoholvrij", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 13, Name = "Whiskey", MemberPrice = 2.00M, Price = 2.50M },
            new Product() { Id = 14, Name = "Vodka", MemberPrice = 2.00M, Price = 2.50M },
            new Product() { Id = 15, Name = "Fanta Zero", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 16, Name = "Sprite Zero", MemberPrice = 1.80M, Price = 2.20M },
            new Product() { Id = 17, Name = "Snickers", MemberPrice = 1.00M, Price = 1.10M },
            new Product() { Id = 18, Name = "Mars", MemberPrice = 1.00M, Price = 1.10M },
            new Product() { Id = 19, Name = "Frikandelletjes", MemberPrice = 2.00M, Price = 2.50M },
            new Product() { Id = 20, Name = "Bitterballen", MemberPrice = 2.00M, Price = 2.50M },
        };
    }

    public async Task<Product> GetProductById(int productId)
    {
        return _products.FirstOrDefault(product => product.Id == productId);
    }

    public async Task<Product> GetProductByName(string productName)
    {
        return _products.FirstOrDefault(product => product.Name == productName);
    }

    public async Task<List<Product>> GetProducts()
    {
        return _products;
    }
}
