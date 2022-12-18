using App.Models;

namespace App.Services;

public interface IOrderDetailService
{
    OrderDetail AddOrderDetail(Order order, Product product);
    void RemoveOrderDetail(OrderDetail orderDetail);

}
