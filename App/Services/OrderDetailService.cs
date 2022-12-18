using App.Contexts;
using App.Models;

namespace App.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly BarkeeperContext _context;
    private readonly IMoneyCalculator _moneyCalculator;

    public OrderDetailService(BarkeeperContext context, IMoneyCalculator moneyCalculator)
    {
        _context = context;
        _moneyCalculator = moneyCalculator;
    }

    public OrderDetail AddOrderDetail(Order order, Product product)
    {
        var orderDetail = new OrderDetail { Order = order, Product = product };
        orderDetail.Price = _moneyCalculator.PricePerOrderDetail(orderDetail, order.IsMember);
        orderDetail.TimeAdded = DateTime.Now;
        return orderDetail;
    }

    public void RemoveOrderDetail(OrderDetail orderDetail)
    {
        _context.OrderDetails.Remove(orderDetail);
        _context.SaveChanges();
    }
}
