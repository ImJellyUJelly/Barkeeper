using App.Models;
using App.Repositories;
using App.Services;
using Moq;
using NUnit.Framework;
using System;

namespace Tests.Services
{
    [TestFixture]
    public class OrderDetailServiceTests
    {
        private Mock<ISessionService> _sessionServiceMock;
        private Mock<IOrderDetailRepository> _orderDetailRepositoryMock;
        private IMoneyCalculator _moneyCalculator;

        [SetUp]
        public void SetUp()
        {
            _sessionServiceMock = new Mock<ISessionService>();
            _orderDetailRepositoryMock = new Mock<IOrderDetailRepository>();
            _moneyCalculator = new MoneyCalculator();
        }

        [TestCase("2.60", "2.60", "true")]
        [TestCase("2.60", "1.00", "false")]
        public void AddOrderDetail_ReturnsAnOrderDetail_WithTheCorrectPrice(decimal eventPrice, decimal expectedPrice, bool isEvent)
        {
            // Arrange
            var product = new Product { EventPrice = eventPrice, Price = 1.00M };
            var order = new Order();
            var session = isEvent ? new Session
            {
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = null
            } : null;

            _sessionServiceMock.Setup(mock => mock.GetCurrentSession())
                .Returns(session);


            var target = new OrderDetailService(_sessionServiceMock.Object, _moneyCalculator, _orderDetailRepositoryMock.Object);

            // Act
            var result = target.AddOrderDetail(order, product);

            // Assert
            Assert.AreEqual(expectedPrice, result.Price);
        }
    }
}
