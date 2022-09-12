using App.Models;

namespace App.Services;

public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int productId);
    Product GetProductByName(string productName);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
}
