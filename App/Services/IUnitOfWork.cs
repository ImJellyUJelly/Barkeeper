using App.Repositories;

namespace App.Services;

public interface IUnitOfWork
{
    public IOrderRepository GetOrderRepository();
    public IProductRepository GetProductRepository();
    public IMemberRepository GetMemberRepository();
}
