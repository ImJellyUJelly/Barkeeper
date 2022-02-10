using Models;

namespace API.Repositories;

public interface IOrderRepository
{
    long CreateOrder(Order order);
    Order GetOrder(int orderId);
}
