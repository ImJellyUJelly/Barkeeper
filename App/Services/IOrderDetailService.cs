using App.Models;

namespace App.Services;

public interface IOrderDetailService
{
    /// <summary>
    /// Add an Product to an Order. The Price of the OrderDetail is set concidering Order.IsMember.
    /// </summary>
    /// <param name="order">The Order the Product is added to.</param>
    /// <param name="product">The Product to add to the Order.</param>
    /// <returns></returns>
    OrderDetail AddOrderDetail(Order order, Product product);

    /// <summary>
    /// Update only the Price of all OrderDetails in an Order.
    /// </summary>
    /// <param name="order">The Order where the OrderDetails should be updated.</param>
    void UpdateOrderDetails(Order order);
    
    /// <summary>
    /// Remove an OrderDetail.
    /// </summary>
    /// <param name="orderDetail">The OrderDetail to remove.</param>
    void RemoveOrderDetail(OrderDetail orderDetail);
}
