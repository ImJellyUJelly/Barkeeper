using API.Repositories;

namespace API.Services;

public interface IUnitOfWork
{
    public IOrderRepository getOrderRepository();
}
