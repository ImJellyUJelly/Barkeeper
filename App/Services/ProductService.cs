using App.Models;
using App.Repositories;

namespace App.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _productRepository = unitOfWork.GetProductRepository();
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
}
