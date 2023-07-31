using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationInNetCore.Controllers
{
   

        [Route("api/Coustmer")]
        [ApiController]
        public class CustomerController : ControllerBase
        {


            private readonly ICustomerRepository _customerRepository;

            public CustomerController(ICustomerRepository customerepository)
            {
                _customerRepository = customerepository;
            }



            [HttpGet]
            public ActionResult<IEnumerable<Customer>> GetCustomers()
            {

                Array array = _customerRepository.GetCustomers().ToArray();

                if (array.Length == 0)
                {
                    return NotFound();
                }
                return Ok(array);
            }

            [HttpGet("{id}")]
            public ActionResult<Customer> GetCustomer(int id)
            {

                Customer? customer = _customerRepository.GetCustomerById(id);



                if (customer == null)
                {
                    return NotFound();
                }


                return customer;
            }

            [HttpPost]
            public ActionResult<Customer> PostCustomer(Customer customer)
            {

                return (Customer)_customerRepository.PostCustomer(customer);


            }

            [HttpPut]

            public ActionResult<Customer> PutCustomer(int id, Customer customer)
            {

                var customerCreated = _customerRepository.PutCustomer(id, customer);

                if (customerCreated == null)
                {
                    return NotFound();
                }



                return customerCreated;


            }



            [HttpDelete("{id}")]

            public ActionResult<Customer> DeleteCustomer(int id)
            {


                var customer = _customerRepository.DeleteCustomer(id);
                if (customer == null)
                    return NotFound();

                return Ok(customer);




            }


        }
    }


