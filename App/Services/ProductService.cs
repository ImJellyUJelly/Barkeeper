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

    public void AddProduct(string name, decimal Price, decimal memberPrice, ProductCategory category, bool isActive)
    {
        var product = new Product()
        {
            Name = name,
            Price = Price,
            EventPrice = memberPrice,
            Category = category,
            IsActive = isActive
        };
        _productRepository.AddProduct(product);
    }

    public void CoinsMustBePresent()
    {
        var product = _productRepository.GetProductByName("Munten");
        if(product == null)
        {
            var coins = new Product();
            coins.Name = "Munten";
            coins.Price = 9.00M;
            coins.EventPrice = 9.00M;
            coins.IsActive = true;
            coins.Category = ProductCategory.Overige;
            _productRepository.AddProduct(coins);
        }
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

    public void UpdateProduct(Product product, string name, decimal Price, decimal memberPrice, ProductCategory category, bool isActive)
    {
        product.Name = name;
        product.Price = Price;
        product.EventPrice = memberPrice;
        product.Category = category;
        product.IsActive = isActive;

        _productRepository.UpdateProduct(product);
    }
}
