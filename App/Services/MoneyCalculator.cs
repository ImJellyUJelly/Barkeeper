﻿using App.Models;

namespace App.Services
{
    public class MoneyCalculator : IMoneyCalculator
    {
        public decimal PricePerOrder(Order order)
        {
            decimal totalPrice = 0.00M;
            if (order.OrderDetails.Count > 0)
            {
                order.OrderDetails.ForEach(od => totalPrice += (order.IsMember ? od.Product.MemberPrice : od.Product.Price));
            }
            else
            {
                totalPrice += order.Price;
            }

            return Math.Round(totalPrice, 2);
        }

        public decimal PriceForMergedOrder(List<Order> orders)
        {
            decimal totalPrice = 0.00M;
            totalPrice += orders.Sum(order => order.Price);
            return Math.Round(totalPrice, 2);
        }

        public decimal SplitPriceForMergedOrder(List<Order> orders)
        {
            decimal totalSplitPrice = 0.00M;
            totalSplitPrice += orders.Sum(order => order.SplitPrice);
            return Math.Round(totalSplitPrice, 2);
        }

        public decimal PricePerSplitOrder(Order order, int numberOfCustomers)
        {
            decimal totalPrice = 0.00M;
            totalPrice += order.Price + order.SplitPrice;
            return Math.Round(totalPrice / numberOfCustomers, 2);
        }
    }
}
