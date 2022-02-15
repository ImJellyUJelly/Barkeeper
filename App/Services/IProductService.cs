using Models;

namespace App.Services;

public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int productId);
    Product GetProductByName(string productName);
}
