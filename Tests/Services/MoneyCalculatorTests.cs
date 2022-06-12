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

        [TestCase("1.00", "1.33")]
        [TestCase("1.33", "2.66")]
        [TestCase("1.333", "2.67")]
        [TestCase("1.99", "3.98")]
        public void PricePerOrder(decimal price, decimal expectedResult)
        {
            // Arrange
            var order = new Order() { Price = price };

            var target = new MoneyCalculator();

            // Act
            decimal result = target.PricePerOrder(order);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
