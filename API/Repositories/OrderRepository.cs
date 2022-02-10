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

    public long CreateOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return order.Id;
    }

    public Order GetOrder(int orderId)
    {
        return _dbContext.Orders.First(order => order.Id == orderId);
    }
}
