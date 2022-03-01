using App.Models;

namespace App.Repositories;

public interface ICustomerRepository
{
    List<Customer> GetAllCustomers();
    Customer FindCustomer(string name);
}
