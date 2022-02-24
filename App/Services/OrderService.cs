using App.Models;
using App.Repositories;

namespace App.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _orderRepository = unitOfWork.getOrderRepository();
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
        return _orderRepository.CreateOrder(order);
    }

    public void DeleteProductFromOrder(Order order, OrderDetail orderDetail)
    {
        order.OrderDetails.Remove(orderDetail);
        order.Price = CalculateOrderPrice(order);
        UpdateOrder(order);
    }

    public Order GetOrderByCustomerName(string customerName)
    {
        return _orderRepository.GetOrderByName(customerName);
    }

    public List<Order> GetOrders()
    {
        return _orderRepository.GetOrders().OrderBy(order => order.CustomerName).ToList();
    }

    public List<Order> GetUnFinishedAndUnPaidOrders()
    {
        return _orderRepository.GetOrders().Where(order => order.IsFinished == false && order.IsPaid == false).ToList(); ;
    }

    public void MergeOrders(List<Order> orderList, string customerName)
    {
        var newOrder = new Order() { CustomerName = customerName, OrderDate = DateTime.Now, IsMember = true };
        newOrder.Comment += "Deze bestelling is samengevoegd uit ID's: ";
        foreach (var order in orderList)
        {
            newOrder.Comment += $"{order.Id} ";
            foreach (var orderDetail in order.OrderDetails)
            {
                AddProductToOrder(newOrder, orderDetail.Product);
            }
        }

        newOrder = CreateOrder(newOrder);
        newOrder.Price = CalculateOrderPrice(newOrder);
        foreach (var order in orderList)
        {
            order.Comment += $"Bestelling is samengevoegd in de bestelling van {newOrder.CustomerName} met ID: {newOrder.Id}.\n";
            order.IsFinished = true;
            UpdateOrder(order);
        }
    }

    public void SplitOrder(Order order, List<Order> newOrders)
    {
        order.Comment += $"Bestelling is opgesplitst in {newOrders.Count} bestellingen.\n";
        order.IsFinished = true;
        foreach (var newOrder in newOrders)
        {
            newOrder.Comment += $"Dit is een gesplitste bestelling van {order.CustomerName}.\n";
            newOrder.ParentOrder = order;
            CreateOrder(newOrder);
        }

        UpdateOrder(order);
    }

    public void UpdateOrder(Order order)
    {
        _orderRepository.UpdateOrder(order);
    }

    public void PayOrder(Order order, decimal amount)
    {
        order.IsPaid = true;
        order.IsFinished = true;
        _orderRepository.UpdateOrder(order);
    }
}
