using App.Contexts;
using App.Models;
using System.Data.Entity;

namespace App.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly BarkeeperContext _dbContext;

    public OrderRepository(BarkeeperContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Order CreateOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return order;
    }

    public Order GetOrderById(int orderId)
    {
        return _dbContext.Orders
            .Include(order => order.Customer)
            .Include(order => order.OrderDetails)
            .First(order => order.Id == orderId);
    }

    public Order GetOrderByName(string customerName)
    {
        var order =_dbContext.Orders
            .Where(order => order.IsPaid == false)
            .Include(order => order.Customer)
            .Include(order => order.OrderDetails)
            .FirstOrDefault(order => order.Customer.Name == customerName);

        if (order is null)
        {
            order = _dbContext.Orders
            .Where(order => order.IsPaid == false)
            .Include(order => order.Customer)
            .Include(order => order.OrderDetails)
            .FirstOrDefault(order => order.CustomerName == customerName);
        }

        return order;
    }

    public List<Order> GetOrders()
    {
        return _dbContext.Orders
            .Include(order => order.Customer)
            .Include(order => order.OrderDetails)
            .ToList();
    }

    public Order UpdateOrder(Order order)
    {
        _dbContext.SaveChanges();
        return order;
    }

    public List<Order> GetOrdersByName(string customerName)
    {
        return _dbContext.Orders.Where(order => order.Customer.Name.Equals(customerName)).ToList();
    }
}
