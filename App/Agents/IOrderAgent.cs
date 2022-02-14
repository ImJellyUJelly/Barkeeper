using Models;

namespace App.Agents;

public interface IOrderAgent
{
    Task CreateOrder(Order order);
    Task<List<Order>> GetOrders();
    Task<Order> GetOrderByName(string name);
    Task UpdateOrder(Order order);
}
