using App.Contexts;
using App.Models;
using App.Repositories;
using App.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Tests.Services
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<BarkeeperContext> _contextMock;

        [SetUp]
        public void Setup()
        {
            var customers = new List<Customer>()
            {
                new Customer() { Id = 0, Name = "Persoon 1" },
                new Customer() { Id = 1, Name = "Persoon 2" }
            };

            _contextMock = new Mock<BarkeeperContext>();

            var customerSetMock = new Mock<DbSet<Customer>>();
            customerSetMock.As<IQueryable<Customer>>().Setup(mock => mock.Customer)
                .Returns(new List<Customer> { new Customer(), new Customer() }.AsQueryable());
            customerSetMock.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);
            customerSetMock.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            customerSetMock.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            customerSetMock.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _contextMock.Setup(mock => mock.Customers).Returns(customerSetMock.Object);
        }

        [Test]
        public void GetCustomers_ReturnsAListOfCustomers()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(mock => mock.GetMemberRepository()).Returns(new CustomerRepository(It.IsAny<BarkeeperContext>()));
            var target = new CustomerService(unitOfWorkMock.Object);

            // Act
            var customers = target.GetCustomers();
            var result = customers.Count;

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
