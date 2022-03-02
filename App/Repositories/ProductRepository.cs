using App.Contexts;
using App.Models;

namespace App.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly BarkeeperContext _context;

    public ProductRepository(BarkeeperContext context)
    {
        _context = context;
    }

    public Product GetProductById(int productId)
    {
        return _context.Products.FirstOrDefault(product => product.Id == productId);
    }

    public Product GetProductByName(string productName)
    {
        return _context.Products.FirstOrDefault(product => product.Name == productName);
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }
}
