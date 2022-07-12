using App.Contexts;
using App.Models;

namespace App.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly BarkeeperContext _context;

    public CustomerRepository(BarkeeperContext context)
    {
        _context = context;
    }

    public Customer AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public void DeleteCustomer(Customer customer)
    {
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    public Customer FindCustomer(string name)
    {
        return _context.Customers.FirstOrDefault(customer => customer.Name.Equals(name));
    }

    public List<Customer> GetAllCustomers()
    {
        return _context.Customers.ToList();
    }

    public Customer UpdateCustomer(Customer customer)
    {
        _context.SaveChanges();
        return customer;
    }
}
