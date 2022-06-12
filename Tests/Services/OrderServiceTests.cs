using App.Models;
using App.Repositories;
using App.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestFixture]
    public class OrderServiceTests
    {
        private IMoneyCalculator _moneyCalculator;

        [SetUp]
        public void SetUp()
        {
            _moneyCalculator = new MoneyCalculator();
        }

        [Test]
        public void GetOrders_ReturnsAnEmptyListOfOrders()
        {
            // Arrange
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(mock => mock.GetOrders()).Returns(new List<Order>());
            var target = new OrderService(orderRepositoryMock.Object, null, null, null);

            // Act
            var result = target.GetOrders();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetOrders_ReturnsAListOfOrders()
        {
            // Arrange
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(mock => mock.GetOrders())
                .Returns(new List<Order> { new Order { Customer = new Customer { Name = "Customer 1" } } });
            var target = new OrderService(orderRepositoryMock.Object, null, null, null);

            // Act
            var result = target.GetOrders();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetUnFinishedAndUnPaidOrders_ReturnsAEmptyListOfUnpaidAndUnFinishedOrders()
        {
            // Arrange
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(mock => mock.GetOrders()).Returns(new List<Order>());
            var target = new OrderService(orderRepositoryMock.Object, null, null, null);

            // Act
            var result = target.GetUnFinishedAndUnPaidOrders();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetUnFinishedAndUnPaidOrders_ReturnsAListOfUnpaidAndUnFinishedOrders()
        {
            // Arrange
            var orderList = new List<Order>
            {
                new Order { IsFinished = true, IsPaid = true },
                new Order { IsFinished = true, IsPaid = false },
                new Order { IsFinished = false, IsPaid = true },
                new Order { IsFinished = false, IsPaid = false }
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(mock => mock.GetOrders()).Returns(orderList);
            var target = new OrderService(orderRepositoryMock.Object, null, null, null);

            // Act
            var result = target.GetUnFinishedAndUnPaidOrders();

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetOrderByCustomerName_ReturnsACustomer()
        {
            // Arrange
            var customer = new Customer { Name = "Customer 1" };
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(mock => mock.GetOrderByName(It.IsAny<string>())).Returns(new Order { Customer = customer });
            var target = new OrderService(orderRepositoryMock.Object, null, null, null);

            // Act
            Order result = target.GetOrderByCustomerName(customer.Name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer.Name, result.Customer.Name);
        }

        [Test]
        public void CreateOrder_ReturnsTheOrderWithCalculatedPrice()
        {
            // Arrange
            var order = new Order()
            {
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail { Product = new Product { Price = 1.20M } },
                    new OrderDetail { Product = new Product { Price = 1.20M } }
                }
            };
            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(mock => mock.CreateOrder(It.IsAny<Order>())).Returns(order);
            var target = new OrderService(orderRepositoryMock.Object, null, null, _moneyCalculator);

            // Act
            Order result = target.CreateOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2.40M, result.Price);
        }
    }
}
