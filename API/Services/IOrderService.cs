using Models;

namespace API.Services;

public interface IOrderService
{
    Order CreateOrder(Order order);
    Order GetOrderById(int orderId);
}
