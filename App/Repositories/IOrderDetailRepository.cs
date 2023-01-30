using App.Models;

namespace App.Repositories;

public interface IOrderDetailRepository
{
    void RemoveOrderDetail(OrderDetail orderDetail);
}