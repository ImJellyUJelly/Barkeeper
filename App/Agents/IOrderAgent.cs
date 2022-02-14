using Models;

namespace App.Agents;

public interface IOrderAgent
{
    Order CreateOrder(Order order);
    List<Order> GetOrders();
    Order GetOrderByName(string name);
    void UpdateOrder(Order order);
}
