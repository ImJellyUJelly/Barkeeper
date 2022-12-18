using App.Models;

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

        public decimal PricePerOrderDetail(OrderDetail detail, bool isMember)
        {
            return isMember ? detail.Product.MemberPrice : detail.Product.Price;
        }

        public decimal PayOrder(Order order, decimal amount)
        {
            decimal remainder = PricePerOrder(order) - amount;
            return remainder;
        }
    }
}
