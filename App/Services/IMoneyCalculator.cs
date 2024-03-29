﻿using App.Models;

namespace App.Services
{
    public interface IMoneyCalculator
    {
        /// <summary>
        /// Calculate the Price for a single order.
        /// </summary>
        /// <param name="order">The order that is going to be split.</param>
        /// <param name="numberOfCustomers">Number of customers that pay the bill.</param>
        /// <returns>The Price of an order that is split from another order.</returns>
        decimal PricePerSplitOrder(Order order, int numberOfCustomers);

        /// <summary>
        /// Calculate the Price for a list of orders all together.
        /// </summary>
        /// <param name="orders">A list of orders.</param>
        /// <returns>The Price for an order that is combined by several other orders.</returns>
        decimal PriceForMergedOrder(List<Order> orders);

        /// <summary>
        /// Calculatte the splitPrice for a list of orders all together.
        /// </summary>
        /// <param name="orders">A list of orders.</param>
        /// <returns>The splitPrice for an order that is combined by several other orders.</returns>
        decimal SplitPriceForMergedOrder(List<Order> orders);

        /// <summary>
        /// Calculate the Price of a single order.
        /// </summary>
        /// <param name="order">An order.</param>
        /// <returns>A Price for one order, including if the customer is a member or not.</returns>
        decimal PricePerOrder(Order order);

        /// <summary>
        /// Calculate whether to use MemberPrice of Price based on IsMember of an Order.
        /// </summary>
        /// <param name="detail">The OrderDetail which needs to calculate Price.</param>
        /// <param name="isEvent">Is the order done during an event.</param>
        /// <returns>A Price per OrderDetail.</returns>
        decimal PricePerOrderDetail(OrderDetail detail, bool isEvent);

        /// <summary>
        /// Pay an Amount for an Order. There may or may not be a remainder that needs to be paid.
        /// </summary>
        /// <param name="order">The Order that is being paid.</param>
        /// <param name="amount">The Amount that is being paid.</param>
        /// <returns>The remainder that needs to be paid. If this is negative, money must be returned to the Customer.</returns>
        decimal GetRemainderAfterPayment(Order order, decimal amount);

        decimal PriceForNoOrder(List<OrderDetail> orderDetails);
        decimal GetCoinsForNoOrder(List<OrderDetail> orderDetails, decimal coinPrice);
        decimal GetRemainderAfterPaymentNoOrder(List<OrderDetail> orderDetails, decimal amount);
    }
}
