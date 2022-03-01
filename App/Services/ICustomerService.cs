using App.Models;

namespace App.Services;

public interface ICustomerService
{
    List<Customer> GetCustomers();
    Customer FindOrCreateCustomer(string customerName);
}
