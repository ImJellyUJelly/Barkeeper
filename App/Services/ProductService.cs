using App.Models;
using App.Repositories;

namespace App.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
    }

    public Product GetProductById(int productId)
    {
        return _productRepository.GetProductById(productId);
    }

    public Product GetProductByName(string productName)
    {
        return _productRepository.GetProductByName(productName);
    }

    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public void UpdateProduct(Product product)
    {
        _productRepository.UpdateProduct(product);
    }
}
