using App.Models;

namespace App.Services
{
    public interface IMoneyCalculator
    {
        /// <summary>
        /// Calculate the price for a single order.
        /// </summary>
        /// <param name="order">The order that is going to be split.</param>
        /// <param name="numberOfCustomers">Number of customers that pay the bill.</param>
        /// <returns>The price of an order that is split from another order.</returns>
        decimal PricePerSplitOrder(Order order, int numberOfCustomers);

        /// <summary>
        /// Calculate the price for a list of orders all together.
        /// </summary>
        /// <param name="orders">A list of orders.</param>
        /// <returns>The price for an order that is combined by several other orders.</returns>
        decimal PriceForMergedOrder(List<Order> orders);

        /// <summary>
        /// Calculatte the splitprice for a list of orders all together.
        /// </summary>
        /// <param name="orders">A list of orders.</param>
        /// <returns>The splitprice for an order that is combined by several other orders.</returns>
        decimal SplitPriceForMergedOrder(List<Order> orders);

        /// <summary>
        /// Calculate the price of a single order.
        /// </summary>
        /// <param name="order">An order.</param>
        /// <returns>A price for one order, including if the customer is a member or not.</returns>
        decimal PricePerOrder(Order order);

        /// <summary>
        /// Calculate whether to use MemberPrice of Price based on IsMember of an Order.
        /// </summary>
        /// <param name="detail">The OrderDetail which needs to calculate price.</param>
        /// <param name="isMember">Is the order from a member.</param>
        /// <returns></returns>
        decimal PricePerOrderDetail(OrderDetail detail, bool isMember);
    }
}
