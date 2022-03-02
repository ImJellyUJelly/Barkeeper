using App.Contexts;
using App.Models;

namespace App.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly BarkeeperContext _context;

    public OrderDetailService(BarkeeperContext context)
    {
        _context = context;
    }

    public void RemoveOrderDetail(OrderDetail orderDetail)
    {
        _context.OrderDetails.Remove(orderDetail);
        _context.SaveChanges();
    }
}
