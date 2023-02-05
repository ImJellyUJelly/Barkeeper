using App.Models;
using App.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestFixture]
    public class MoneyCalculatorTests
    {
        [TestCase("10.00", "2", "5.00")]
        [TestCase("10.00", "3", "3.33")]
        [TestCase("10.00", "4", "2.50")]
        [TestCase("9.00", "4", "2.25")]
        [TestCase("10.99", "5", "2.20")]
        public void PriceForSplitOrders_ReturnsTheRightAmountPerCustomers(decimal price, int customers, decimal expectedResult)
        {
            // Arrange
            var order = new Order() { Price = price };
            var target = new MoneyCalculator();

            // Act
            decimal result = target.PricePerSplitOrder(order, customers);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1.00", "1.00", "2.00")]
        [TestCase("1.33", "1.20", "2.53")]
        [TestCase("1.333", "1.333", "2.67")]
        public void PriceForMerdedOrder(decimal price1, decimal price2, decimal expectedResult)
        {
            // Arrange
            var orders = new List<Order>() 
            { 
                new Order() { Price = price1 }, 
                new Order() { Price = price2 } 
            };

            var target = new MoneyCalculator();

            // Act
            decimal result = target.PriceForMergedOrder(orders);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1.00", "2.00")]
        [TestCase("1.33", "2.66")]
        [TestCase("1.333", "2.67")]
        [TestCase("1.99", "3.98")]
        public void PricePerOrder(decimal price, decimal expectedResult)
        {
            // Arrange
            var orderDetails = new List<OrderDetail>
            {
                new OrderDetail() { Price = price },
                new OrderDetail() { Price = price }
            };

            var order = new Order() { OrderDetails = orderDetails };

            var target = new MoneyCalculator();

            // Act
            decimal result = target.PricePerOrder(order);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("12.00", "-2.00")]
        [TestCase("8.00", "2.00")]
        public void PayOrder_ReturnsRemainder(decimal amount, decimal expectedResult)
        {
            // Arrange
            var order = new Order()
            {
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail { Price = 10.00M },
                }
            };
            var target = new MoneyCalculator();

            // Act
            var result = target.GetRemainderAfterPayment(order, amount);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("10.00", "1.50", "-0.50")]
        [TestCase("10.00", "2.00", "0.00")]
        [TestCase("10.00", "4.00", "2.00")]
        public void PayOrder_ReturnsRemainder_WithSplitPrice(decimal amount, decimal splitPrice, decimal expectedResult)
        {
            // Arrange
            var order = new Order()
            {
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail { Price = 8.00M },
                },
                SplitPrice = splitPrice
            };
            var target = new MoneyCalculator();

            // Act
            var result = target.GetRemainderAfterPayment(order, amount);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}