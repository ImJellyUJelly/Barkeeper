using Models;

namespace App.Agents;

public interface IOrderAgent
{
    void CreateOrder(Order order);
    List<Order> GetOrders();
    Order GetOrderByName(string name);
    void UpdateOrder(Order order);
}
