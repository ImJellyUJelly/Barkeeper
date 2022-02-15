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

    public OrderDetail AddProductToOrder(Order order, Product product)
    {
        var orderDetail = new OrderDetail() { Order = order, Product = product, TimeAdded = DateTime.Now };
        order.OrderDetails.Add(orderDetail);
        order.Price = CalculateOrderPrice(order);
        UpdateOrder(order);
        return orderDetail;
    }

    public decimal CalculateOrderPrice(Order order)
    {
        decimal totalPrice = 0.00M;
        order.OrderDetails.ForEach(od => totalPrice += (order.IsMember ? od.Product.MemberPrice : od.Product.Price));
        return totalPrice;
    }

    public Order CreateOrder(Order order)
    {
        order.OrderDate = DateTime.Now;
        order.Price = CalculateOrderPrice(order);
        return _orderAgent.CreateOrder(order).Result;
    }

    public void DeleteProductFromOrder(Order order, OrderDetail orderDetail)
    {
        order.OrderDetails.Remove(orderDetail);
        order.Price = CalculateOrderPrice(order);
        UpdateOrder(order);
    }

    public Order GetOrderByCustomerName(string customerName)
    {
        return _orderAgent.GetOrderByName(customerName).Result;
    }

    public List<Order> GetOrders()
    {
        return _orderAgent.GetOrders().Result.OrderBy(order => order.CustomerName).ToList();
    }

    public void MergeOrders(List<Order> orderList, string customerName)
    {
        var newOrder = new Order() { CustomerName = customerName, OrderDate = DateTime.Now, IsMember = true };
        foreach (var order in orderList)
        {
            newOrder.Comment += $"{order.Id} ";
            foreach (var orderDetail in order.OrderDetails)
            {
                var od = new OrderDetail() { Order = newOrder, Product = orderDetail.Product, TimeAdded = DateTime.Now };
                newOrder.OrderDetails.Add(od);
                if (order.IsMember)
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
        foreach (var order in orderList)
        {
            order.Comment = $"Bestelling is samengevoegd in de bestelling van {newOrder.CustomerName} met ID: {newOrder.Id}.\n";
            order.IsFinished = true;
            UpdateOrder(order);
        }
    }

    public void SplitOrder(Order order, int numberOfCustomers, List<Order> newOrders)
    {
        order.Comment += $"Bestelling is opgesplitst in {numberOfCustomers} bestellingen.\n";
        order.IsFinished = true;
        foreach(var newOrder in newOrders)
        {
            CreateOrder(newOrder);
        }

        UpdateOrder(order);
    }

    public void UpdateOrder(Order order)
    {
        order.Price = CalculateOrderPrice(order);
        _orderAgent.UpdateOrder(order);
    }
}
