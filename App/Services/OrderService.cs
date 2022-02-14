using App.Agents;
using Models;

namespace App.Services;

public class OrderService : IOrderService
{
    private readonly IOrderAgent _orderAgent;

    public OrderService(IOrderAgent orderAgent)
    {
        _orderAgent = orderAgent;
    }

    public void AddProductToOrder(Order order, Product product)
    {
        order.OrderDetails.Add(new OrderDetail() { Order = order, Product = product, TimeAdded = DateTime.Now });
    }

    public decimal CalculateOrderPrice(Order order)
    {
        decimal totalPrice = 0.00M;
        if (order.IsMember)
        {
            order.OrderDetails.ForEach(od => totalPrice += od.Product.MemberPrice);
        }
        else
        {
            order.OrderDetails.ForEach(od => totalPrice += od.Product.Price);
        }
        return totalPrice;
    }

    public void CreateOrder(Order order)
    {
        _orderAgent.CreateOrder(order);
    }

    public Order GetOrderByCustomerName(string customerName)
    {
        return _orderAgent.GetOrderByName(customerName).Result;
    }

    public List<Order> GetOrders()
    {
        return _orderAgent.GetOrders().Result.OrderBy(order => order.CustomerName).ToList();
    }

    public void UpdateOrder(Order order)
    {
        _orderAgent.UpdateOrder(order);
    }
}
