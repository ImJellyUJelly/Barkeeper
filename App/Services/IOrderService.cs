using App.Models;

namespace App.Services;

public interface IOrderService
{
    List<Order> GetOrders();
    List<Order> GetUnFinishedAndUnPaidOrders();

    Order GetOrderByCustomerName(string customerName);
    Order CreateOrder(Order order);
    void DeleteProductFromOrder(Order order, OrderDetail product);
    void UpdateOrder(Order order);
    OrderDetail AddProductToOrder(Order order, Product product);

    void MergeOrders(List<Order> orderList, string customerName);
    void SplitOrder(Order order, Dictionary<string, decimal> newOrders);
    void PayOrder(Order order, decimal amount);
}
