using Models;

namespace App.Agents;

public interface IOrderAgent
{
    Task<Order> CreateOrder(Order order);
    Task<List<Order>> GetOrders();
    Task<Order> GetOrderByName(string name);
    Task<Order> UpdateOrder(Order order);
}
