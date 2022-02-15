using Models;

namespace App.Agents;

public interface IProductAgent
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProductById(int productId);
    Task<Product> GetProductByName(string productName);
}
