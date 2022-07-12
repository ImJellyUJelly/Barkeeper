using App.Models;

namespace App.Repositories;

public interface ICustomerRepository
{
    List<Customer> GetAllCustomers();
    Customer FindCustomer(string name);
    Customer AddCustomer(Customer customer);
    Customer UpdateCustomer(Customer customer);
    void DeleteCustomer(Customer customer);
}
