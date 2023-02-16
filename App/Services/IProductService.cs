using App.Models;

namespace App.Services;

public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int productId);
    Product GetProductByName(string productName);
    void AddProduct(string name, decimal Price, decimal memberPrice, ProductCategory category, bool isActive);
    void UpdateProduct(Product product, string name, decimal Price, decimal memberPrice, ProductCategory category, bool isActive);
    void CoinsMustBePresent();
}
