using App.Models;
using App.Repositories;
using App.Services;
using Moq;
using NUnit.Framework;

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

        [TestCase("true", "2.60", "2.60")]
        [TestCase("false", "2.60", "1.00")]
        public void AddOrderDetail_ReturnsAnOrderDetail_WithTheCorrectPrice(
            bool isEvent, decimal eventPrice, decimal expectedPrice)
        {
            // Arrange
            var product = new Product { EventPrice = eventPrice, Price = 1.00M };
            var order = new Order();

            _sessionServiceMock.Setup(mock => mock.GetCurrentSession()).Returns(new Session { IsEvent = isEvent });

            var target = new OrderDetailService(_sessionServiceMock.Object, _moneyCalculator, _orderDetailRepositoryMock.Object);

            // Act
            var result = target.AddOrderDetail(order, product);

            // Assert
            Assert.AreEqual(expectedPrice, result.Price);
        }
    }
}
