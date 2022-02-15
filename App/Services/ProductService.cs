using App.Agents;
using Models;

namespace App.Services;

public class ProductService : IProductService
{
    private readonly IProductAgent _productAgent;

    public ProductService(IProductAgent productAgent)
    {
        _productAgent = productAgent;
    }

    public Product GetProductById(int productId)
    {
        return _productAgent.GetProductById(productId).Result;
    }

    public Product GetProductByName(string productName)
    {
        return _productAgent.GetProductByName(productName).Result;
    }

    public List<Product> GetProducts()
    {
        return _productAgent.GetProducts().Result;
    }
}
