using App.Models;

namespace App.Services;

public interface ICustomerService
{
    event EventHandler<Customer> CustomerAdded;
    event EventHandler<Customer> CustomerEdited;
    event EventHandler<string> CustomerDeleted;

    /// <summary>
    /// Get a list of all customers.
    /// </summary>
    /// <returns>List of customers.</returns>
    List<Customer> GetCustomers();
    /// <summary>
    /// Find a customer by name. If customer does not exist, a new customer is created.
    /// </summary>
    /// <param name="customerName">The (full) name of the customer.</param>
    /// <returns></returns>
    Customer FindOrCreateCustomer(string customerName);
    /// <summary>
    /// Update existing customer.
    /// </summary>
    /// <param name="customer">A customer.</param>
    /// <returns>Updated customer with ID.</returns>
    Customer UpdateCustomer(Customer customer);
    /// <summary>
    /// Update an existing customer. If the customer doesn't exist, create a new one.
    /// </summary>
    /// <param name="customer">The customer to be added or updated.</param>
    void UpdateOrCreateCustomer(Customer customer);
    /// <summary>
    /// Delete an existing customer.
    /// </summary>
    /// <param name="customer">A customer.</param>
    void DeleteCustomer(Customer customer);
    
    /// <summary>
    /// Find a customer by it's name.
    /// </summary>
    /// <param name="customerName">Name of the custome.</param>
    /// <returns></returns>
    Customer FindCustomer(string customerName);
}
