using CrudOperationInNetCore.Models;

namespace CrudOperationInNetCore.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();

        Customer? GetCustomerById(int id);

        Customer PostCustomer(Customer customer);

        Customer? PutCustomer(int id, Customer customer);


        Customer? DeleteCustomer(int id);

    }
}
