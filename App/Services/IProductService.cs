using App.Models;

namespace App.Services;

public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int productId);
    Product GetProductByName(string productName);
    void AddProduct(string name, decimal price, decimal memberPrice, ProductCategory category);
    void UpdateProduct(Product product, string name, decimal price, decimal memberPrice, ProductCategory category);
}
