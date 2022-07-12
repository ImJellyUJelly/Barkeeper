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
            _customerRepository.AddCustomer(customer);
        }

        return customer;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        if(customer == null)
        {
            return null;
        }

        _customerRepository.UpdateCustomer(customer);
        return customer;
    }

    public void DeleteCustomer(Customer customer)
    {
        if(customer == null)
        {
            return;
        }

        _customerRepository.DeleteCustomer(customer);
    }
}
