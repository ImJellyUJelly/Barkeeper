using App.Models;
using App.Repositories;
using System;

namespace App.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public event EventHandler<Customer> CustomerAdded;
    public event EventHandler<Customer> CustomerEdited;
    public event EventHandler<string> CustomerDeleted;

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
            customer = _customerRepository.AddCustomer(new Customer { Name = customerName});
            CustomerAdded?.Invoke(this, customer);
        }

        return customer;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        if(customer == null)
        {
            return null;
        }

        customer = _customerRepository.UpdateCustomer(customer);
        CustomerEdited?.Invoke(this, customer);
        return customer;
    }

    public void DeleteCustomer(Customer customer)
    {
        if(customer == null)
        {
            return;
        }

        BeforeCustomerDeleted(customer.Name);
        _customerRepository.DeleteCustomer(customer);
    }

    public void UpdateOrCreateCustomer(Customer customer)
    {
        if (customer == null)
        {
            return;
        }

        var foundCustomer = _customerRepository.FindCustomer(customer.Name);
        if (foundCustomer == null)
        {
            _customerRepository.AddCustomer(customer);
            CustomerAdded?.Invoke(this, customer);
        }
        else
        {
            customer.Id = foundCustomer.Id;
            _customerRepository.UpdateCustomer(customer);
            CustomerEdited?.Invoke(this, customer);
        }
    }

    protected virtual void BeforeCustomerDeleted(string customerName)
    {
        CustomerDeleted?.Invoke(this, customerName);
    }

    public Customer FindCustomer(string customerName)
    {
        return _customerRepository.FindCustomer(customerName);
    }
}
