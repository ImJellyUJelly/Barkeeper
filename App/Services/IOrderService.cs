using Models;

namespace App.Services;

public interface IOrderService
{
    decimal CalculateOrderPrice(Order order);
    Order GetOrderByCustomerName(string customerName);
    List<Order> GetOrders();
    Order CreateOrder(Order order);
    SplitOrder CreateSplitOrder(SplitOrder splitOrder);
    void DeleteProductFromOrder(Order order, OrderDetail product);
    void UpdateOrder(Order order);
    OrderDetail AddProductToOrder(Order order, Product product);
    void MergeOrders(List<Order> orderList, string customerName);
    void SplitOrder(Order order, int numberOfCustomers, List<Order> newOrders);
}
