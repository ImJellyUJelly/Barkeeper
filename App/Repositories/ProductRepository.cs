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

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public Product GetProductById(int productId)
    {
        return _context.Products.FirstOrDefault(product => product.Id == productId);
    }

    public Product GetProductByName(string productName)
    {
        return _context.Products.FirstOrDefault(product => product.Name.Equals(productName));
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public void UpdateProduct(Product product)
    {
        var prod = _context.Products.First(p => p.Id == product.Id);
        prod = product;
        _context.SaveChanges();
    }
}
