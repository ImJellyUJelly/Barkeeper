using App.Repositories;

namespace App.Services;

public interface IUnitOfWork
{
    public IOrderRepository getOrderRepository();
    public IProductRepository GetProductRepository();
}
