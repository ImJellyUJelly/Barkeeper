using App.Models;
using App.Repositories;

namespace App.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _customerRepository = unitOfWork.GetMemberRepository();
    }

    public List<Customer> GetCustomers()
    {
        return _customerRepository.GetAllCustomers();
    }

    public Customer FindOrCreateCustomer(string customerName)
    {
        var customer = _customerRepository.FindCustomer(customerName);
        if (customer != null)
        {
            return customer;
        }

        Customer newCustomer = new Customer() { Name = customerName };
        return newCustomer;
    }
}
