using Models;

namespace API.Services;

public interface IOrderService
{
    Order CreateOrder(Order order);
    Order GetOrderById(int orderId);
    Order GetOrderByName(string customerName);
    List<Order> GetOrders();
    Order UpdateOrder(Order order);
}
