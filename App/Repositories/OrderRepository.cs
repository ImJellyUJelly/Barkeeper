using App.Contexts;
using App.Models;
using System.Data.Entity;

namespace App.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly BarkeeperContext _dbContext;

    // For testing only
    //private readonly List<Order> _orders;
    //private readonly IProductRepository _productRepository;

    public OrderRepository(BarkeeperContext dbContext, IProductRepository productRepository)
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
        return _dbContext.Orders
            .Where(order => order.IsPaid == false)
            .Include(order => order.Customer)
            .Include(order => order.OrderDetails)
            .FirstOrDefault(order => order.Customer.Name == customerName);
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
}
