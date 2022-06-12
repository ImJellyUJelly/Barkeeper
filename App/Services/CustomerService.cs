using App.Models;
using App.Repositories;

namespace App.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public List<Customer> GetCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }

    public Customer FindOrCreateCustomer(string customerName)
    {
        var customer = _customerRepository.FindCustomer(customerName);
        if (customer == null)
        {
            customer = new Customer() { Name = customerName };
        }

        return customer;
    }
}
