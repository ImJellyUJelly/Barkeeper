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

    public Order CreateOrder(Order order)
    {
        return _orderAgent.CreateOrder(order);
    }

    public Order GetOrderByCustomerName(string customerName)
    {
        return _orderAgent.GetOrderByName(customerName);
    }

    public List<Order> GetOrders()
    {
        return _orderAgent.GetOrders().OrderBy(order => order.CustomerName).ToList();
    }

    public void MergeOrders(List<Order> orderList, string customerName)
    {
        var newOrder = new Order() { CustomerName = customerName, OrderDate = DateTime.Now, IsMember = true, Comment = "Samengevoegde bestelling van IDs: " };
        foreach(var order in orderList)
        {
            newOrder.Comment += $"{order.Id} ";
            foreach (var orderDetail in order.OrderDetails)
            {
                var od = new OrderDetail() { Order = newOrder, Product = orderDetail.Product, TimeAdded = DateTime.Now};
                newOrder.OrderDetails.Add(od);
                if(order.IsMember)
                {
                    order.Price += orderDetail.Product.MemberPrice;
                }
                else
                {
                    order.Price += orderDetail.Product.Price;
                }
            }
        }

        newOrder = CreateOrder(newOrder);
        foreach(var order in orderList)
        {
            order.Comment = $"Bestelling is samengevoegd in de bestelling van {newOrder.CustomerName} met ID: {newOrder.Id}";
            UpdateOrder(order);
        }
    }

    public void UpdateOrder(Order order)
    {
        _orderAgent.UpdateOrder(order);
    }
}
