using App.Models;

namespace App.Services;

public interface IOrderService
{
    List<Order> GetOrders();
    List<Order> GetUnFinishedAndUnPaidOrders();
    List<Order> GetAllOrderByCustomerName(string customerName);

    Order GetOrderByCustomerName(string customerName);
    Order CreateOrder(Order order);
    void DeleteProductFromOrder(Order order, OrderDetail product);
    void UpdateOrder(Order order);
    OrderDetail AddProductToOrder(Order order, Product product);

    void MergeOrders(List<Order> orderList, string customerName);
    void SplitOrder(Order order, Dictionary<string, decimal> newOrders);
    
    /// <summary>
    /// Calculate the remainder of the order. When the remainder is > 0 the customer still needs to pay. 
    /// When the remainders is < 0 the customer gets money back.
    /// </summary>
    /// <param name="order">Order to pay.</param>
    /// <param name="amount">Amount being payed.</param>
    /// <param name="payMethod">The method used to pay.</param>
    /// <returns>Remainder of the order to pay or get back.</returns>
    decimal PayOrder(Order order, decimal amount, PayMethod payMethod);
    decimal PayNoOrder(List<OrderDetail> orderDetails, decimal amount, PayMethod payMethod);
    void FinishOrder(Order order);
}
