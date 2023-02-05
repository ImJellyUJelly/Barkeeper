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
        private Mock<IMoneyCalculator> _moneyCalculatorMock;
        private Mock<IRevenueService> _revenueServiceMock;
        private Mock<IOrderRepository> _orderRepositoryMock;
        private Mock<ICustomerService> _customerServiceMock;
        private Mock<IOrderDetailService> _orderDetailService;

        [SetUp]
        public void SetUp()
        {
            _moneyCalculatorMock = new Mock<IMoneyCalculator>();
            _revenueServiceMock = new Mock<IRevenueService>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _customerServiceMock = new Mock<ICustomerService>();
            _orderDetailService = new Mock<IOrderDetailService>();
        }

        [Test]
        public void GetOrders_ReturnsAnEmptyListOfOrders()
        {
            // Arrange
            _orderRepositoryMock.Setup(mock => mock.GetOrders()).Returns(new List<Order>());
            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, null, null, _revenueServiceMock.Object);

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
            _orderRepositoryMock.Setup(mock => mock.GetOrders())
                .Returns(new List<Order> { new Order { Customer = new Customer { Name = "Customer 1" } } });
            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, null, null, _revenueServiceMock.Object);

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
            _orderRepositoryMock.Setup(mock => mock.GetOrders()).Returns(new List<Order>());
            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, null, null, _revenueServiceMock.Object);

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

            _orderRepositoryMock.Setup(mock => mock.GetOrders()).Returns(orderList);
            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, null, null, _revenueServiceMock.Object);

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
            _orderRepositoryMock.Setup(mock => mock.GetOrderByName(It.IsAny<string>())).Returns(new Order { Customer = customer });
            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, null, null, _revenueServiceMock.Object);

            // Act
            Order result = target.GetOrderByCustomerName(customer.Name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customer.Name, result.GetName());
        }

        [Test]
        public void CreateOrder_ReturnsTheOrderWithCalculatedPrice()
        {
            // Arrange
            var order = new Order() { 
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail { Price = 1.20M },
                    new OrderDetail { Price = 1.20M }
                }
            };

            _orderRepositoryMock.Setup(mock => mock.CreateOrder(It.IsAny<Order>())).Returns(order);
            _moneyCalculatorMock.Setup(mock => mock.PricePerOrder(It.IsAny<Order>())).Returns(2.40M);

            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, null, _moneyCalculatorMock.Object, _revenueServiceMock.Object);

            // Act
            Order result = target.CreateOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2.40M, result.Price);
        }

        [TestCase("15", "10", "5")]
        [TestCase("10", "10", "0")]
        [TestCase("10", "20", "-10")]
        [TestCase("10.50", "20", "-9.50")]
        [TestCase("3.99", "2.75", "1.24")]
        [TestCase("2.75", "4.00", "-1.25")]
        [TestCase("10", "10.50", "-0.50")]
        public void PayOrder_ReturnsRemainder(decimal price, decimal amount, decimal expectedRemainder)
        {
            // Arrange
            Order order = new Order { Price = price };

            _orderRepositoryMock.Setup(mock => mock.CreateOrder(It.IsAny<Order>())).Returns(order);
            _orderDetailService.Setup(mock => mock.UpdateOrderDetails(It.IsAny<Order>()));
            _moneyCalculatorMock.Setup(mock => mock.GetRemainderAfterPayment(It.IsAny<Order>(), It.IsAny<decimal>())).Returns(expectedRemainder);

            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, _orderDetailService.Object, _moneyCalculatorMock.Object, _revenueServiceMock.Object);

            // Act
            var result = target.PayOrder(order, amount, It.IsAny<PayMethod>());

            // Assert
            Assert.AreEqual(expectedRemainder, result);
            _revenueServiceMock.Verify(mock => mock.AddPayment(It.IsAny<Revenue>()), Times.Once);
        }

        [TestCase("2.00", "2.00", "true")]
        [TestCase("2.00", "1.00", "false")]
        public void AddProductToOrder_WhenAnEvent_ThenPriceWillBeCorrect(decimal eventPrice, decimal expectedPrice, bool isEvent)
        {
            // Arrange
            var product = new Product { EventPrice = eventPrice, Price = 1.00M };
            var order = new Order();
            var orderDetail = new OrderDetail { Product = product, Order = order, Price = isEvent ? product.EventPrice : product.Price };
            var moneyCalculator = new MoneyCalculator();

            _orderDetailService.Setup(mock => mock.AddOrderDetail(It.IsAny<Order>(), It.IsAny<Product>())).Returns(orderDetail);

            var target = new OrderService(_orderRepositoryMock.Object, _customerServiceMock.Object, _orderDetailService.Object, moneyCalculator, _revenueServiceMock.Object);

            // Act
            var result = target.AddProductToOrder(order, product);

            // Assert
            Assert.AreEqual(expectedPrice, result.Price);
        }
    }
}
