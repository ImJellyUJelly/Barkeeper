using Models;

namespace App.Services;

public interface IOrderService
{
    decimal CalculateOrderPrice(Order order);
    Order GetOrderByCustomerName(string customerName);
    List<Order> GetOrders();
    Order CreateOrder(Order order);
    void UpdateOrder(Order order);
    void AddProductToOrder(Order order, Product product);
    void MergeOrders(List<Order> orderList, string customerName);
}
