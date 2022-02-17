using App.Models;

namespace App.Repositories;

public interface IProductRepository
{
    Product GetProductById(int productId);
    Product GetProductByName(string productName);
    List<Product> GetProducts();
}
