using App.Models;
using App.Repositories;
using App.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestFixture]
    public class CustomerServiceTests
    {
        [Test]
        public void GetCustomers_ReturnsAListOfCustomers()
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.GetAllCustomers())
                .Returns(new List<Customer> { new Customer(), new Customer() });

            var target = new CustomerService(customerRepositoryMock.Object);

            // Act
            var customers = target.GetCustomers();
            var result = customers.Count;

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void FindOrCreateCustomer_ReturnsCustomer_IfCustomerExists()
        {
            // Arrange
            var customerName = "Customer 1";
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.FindCustomer(customerName))
                .Returns(new Customer() { Name = customerName });

            var target = new CustomerService(customerRepositoryMock.Object);

            // Act
            var result = target.FindOrCreateCustomer(customerName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerName, result.Name);
        }

        [Test]
        public void FindOrCreateCustomer_ReturnsNewCustomer_IfCustomerDoesntExists()
        {
            // Arrange
            var customerName = "Customer 1";
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(mock => mock.FindCustomer(customerName))
                .Returns(() => null);
            customerRepositoryMock.Setup(mock => mock.AddCustomer(It.IsAny<Customer>())).Returns(new Customer() { Name = customerName });

            var target = new CustomerService(customerRepositoryMock.Object);

            // Act
            var result = target.FindOrCreateCustomer(customerName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerName, result.Name);
        }
    }
}
