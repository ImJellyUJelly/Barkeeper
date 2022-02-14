using Models;

namespace API.Repositories;

public interface IOrderRepository
{
    Order CreateOrder(Order order);
    Order GetOrderById(int orderId);
    Order GetOrderByName(string customerName);
}
