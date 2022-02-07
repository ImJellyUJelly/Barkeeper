using Models;

namespace App.Agents;

public interface IOrderAgent
{
    void CreateOrder(Order order);
    List<Order> GetOrders();
}
