using CrudOperationInNetCore.Context;
using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;


namespace CrudOperationInNetCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BrandContext _dbContext;

        public CustomerRepository(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        public Customer? DeleteCustomer(int id)
        {
            var b = _dbContext.Customer.Where(c => c.Id == id).FirstOrDefault();

            _dbContext.Customer.Remove(b);

            _dbContext.SaveChanges();


            return b;

        }

        public Customer? GetCustomerById(int id)
        {
            var b = _dbContext.Customer.Where(c => c.Id == id).FirstOrDefault();

            return b;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customer.ToArray();

        }

        public Customer PostCustomer(Customer customer)
        {
            _dbContext.Customer.Add(customer);

            _dbContext.SaveChanges();

            return customer;

        }

        public Customer? PutCustomer(int id, Customer customer)
        {

            var b = _dbContext.Customer.Where(c => c.Id == id).FirstOrDefault();

            if (b != null)
            {


                b.CustomerName = customer.CustomerName;

                b.Email = customer.Email;

                b.Phone = customer.Phone;

                b.BrandId = customer.BrandId;

                b.OrderId = customer.OrderId;

                _dbContext.SaveChanges();

                return b;


            }

            return null;

        }
    }
}
