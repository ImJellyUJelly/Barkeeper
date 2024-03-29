﻿using App.Models;

namespace App.Services
{
    public class MoneyCalculator : IMoneyCalculator
    {
        public decimal PricePerOrder(Order order)
        {
            decimal totalPrice = 0.00M;
            order.OrderDetails.ForEach(od => totalPrice += od.Price);
            totalPrice += order.SplitPrice;
            totalPrice -= order.PaidAmount;
            return Math.Round(totalPrice, 2);
        }

        public decimal PriceForMergedOrder(List<Order> orders)
        {
            decimal totalPrice = 0.00M;
            totalPrice += orders.Sum(order => order.Price);
            totalPrice -= orders.Sum(order => order.PaidAmount);
            return Math.Round(totalPrice, 2);
        }

        public decimal SplitPriceForMergedOrder(List<Order> orders)
        {
            decimal totalSplitPrice = 0.00M;
            totalSplitPrice += orders.Sum(order => order.SplitPrice);
            totalSplitPrice -= orders.Sum(order => order.PaidAmount);
            return Math.Round(totalSplitPrice, 2);
        }

        public decimal PricePerSplitOrder(Order order, int numberOfCustomers)
        {
            decimal totalPrice = 0.00M;
            totalPrice += order.Price + order.SplitPrice;
            totalPrice -= order.PaidAmount;
            return Math.Round(totalPrice / numberOfCustomers, 2);
        }

        public decimal PricePerOrderDetail(OrderDetail detail, bool isEvent)
        {
            return isEvent ? detail.Product.EventPrice : detail.Product.Price;
        }

        public decimal GetRemainderAfterPayment(Order order, decimal amount)
        {
            decimal remainder = PricePerOrder(order) - amount;
            return remainder;
        }

        public int CalculateTotalCoinsPerOrder(Order order)
        {
            if (order.Price <= 0) PricePerOrder(order);

            int coins = 0;
            order.OrderDetails.ForEach(od => coins += od.Coins);

            return coins;
        }

        public decimal PriceForNoOrder(List<OrderDetail> orderDetails)
        {
            decimal totalPrice = 0.00M;
            orderDetails.ForEach(od => totalPrice += od.Price);
            return Math.Round(totalPrice, 2);
        }

        public decimal GetCoinsForNoOrder(List<OrderDetail> orderDetails, decimal coinPrice)
        {
            decimal totalPrice = 0.00M;
            orderDetails.ForEach(od => totalPrice += od.Price);
            return Math.Round(totalPrice / coinPrice);
        }

        public decimal GetRemainderAfterPaymentNoOrder(List<OrderDetail> orderDetails, decimal amount)
        {
            return PriceForNoOrder(orderDetails) - amount;
        }
    }
}
