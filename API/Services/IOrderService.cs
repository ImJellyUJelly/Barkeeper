using Models;

namespace API.Services;

public interface IOrderService
{
    long CreateOrder(Order order);
    Order GetOrderById(int orderId);
}
