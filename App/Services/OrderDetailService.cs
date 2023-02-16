using App.Models;
using App.Repositories;

namespace App.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly IMoneyCalculator _moneyCalculator;

    public OrderDetailService(ISessionService sessionService, IMoneyCalculator moneyCalculator, IOrderDetailRepository orderDetailRepository)
    {
        _moneyCalculator = moneyCalculator;
        SessionService = sessionService;
        Repository = orderDetailRepository;
    }

    private IOrderDetailRepository Repository { get; }
    private ISessionService SessionService { get; }

    public OrderDetail AddOrderDetail(Order order, Product product)
    {
        var orderDetail = new OrderDetail { Order = order, Product = product };
        orderDetail.Price = _moneyCalculator.PricePerOrderDetail(orderDetail, IsEvent());
        orderDetail.TimeAdded = DateTime.Now;
        return orderDetail;
    }

    public void UpdateOrderDetails(Order order)
    {
        foreach (var orderDetail in order.OrderDetails)
        {
            orderDetail.Price = _moneyCalculator.PricePerOrderDetail(orderDetail, IsEvent());
        }
    }

    public void RemoveOrderDetail(OrderDetail orderDetail)
    {
        Repository.RemoveOrderDetail(orderDetail);
    }

    private bool IsEvent()
    {
        return SessionService.GetCurrentSession() is not null;
    }
}