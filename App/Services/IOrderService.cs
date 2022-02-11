using Models;

namespace App.Services;

public interface IOrderService
{
    decimal CalculateOrderPrice(Order order);
    Order GetOrderByCustomerName(string customerName);
    List<Order> GetOrders();
    void CreateOrder(Order order);
    void UpdateOrder(Order order);
    void AddProductToOrder(Order order, Product product);
}
