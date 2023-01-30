using App.Contexts;
using App.Models;

namespace App.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    public OrderDetailRepository(BarkeeperContext context)
    {
        Context = context;
    }

    private BarkeeperContext Context { get; }

    public void RemoveOrderDetail(OrderDetail orderDetail)
    {
        Context.OrderDetails.Remove(orderDetail);
        Context.SaveChanges();
    }
}