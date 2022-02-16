using API.Contexts;
using Models;

namespace API.Repositories;

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
        return _dbContext.Orders.First(order => order.Id == orderId);
    }

    public Order GetOrderByName(string customerName)
    {
        return _dbContext.Orders
            .Where(order => order.IsPaid == false)
            .First(order => order.CustomerName == customerName);
    }

    public List<Order> GetOrders()
    {
        return _dbContext.Orders.ToList();
    }

    public Order UpdateOrder(Order order)
    {
        var foundOrder = _dbContext.Orders.First(o => o.Id == order.Id);
        foundOrder = order;
        _dbContext.SaveChanges();
        return foundOrder;
    }
}
