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

    public void AddProduct(string name, decimal price, decimal memberPrice, ProductCategory category, bool isActive)
    {
        var product = new Product()
        {
            Name = name,
            Price = price,
            EventPrice = memberPrice,
            Category = category,
            IsActive = isActive
        };
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

    public void UpdateProduct(Product product, string name, decimal price, decimal memberPrice, ProductCategory category, bool isActive)
    {
        product.Name = name;
        product.Price = price;
        product.EventPrice = memberPrice;
        product.Category = category;
        product.IsActive = isActive;

        _productRepository.UpdateProduct(product);
    }
}
