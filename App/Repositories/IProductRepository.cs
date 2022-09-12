using App.Models;

namespace App.Repositories;

public interface IProductRepository
{
    Product GetProductById(int productId);
    Product GetProductByName(string productName);
    List<Product> GetProducts();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
}
