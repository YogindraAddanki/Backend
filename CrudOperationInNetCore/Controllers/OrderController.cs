using Microsoft.AspNetCore.Mvc;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using CrudOperationInNetCore.Interfaces;

namespace CrudOperationInNetCore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            Array array = (Array)_orderRepository.GetAllOrders();

            if (array.Length == 0)
            {
                return NotFound();
            }
            return Ok(array);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {

            Order order = _orderRepository.GetOrderById(id);
            
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }



        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            Order o = _orderRepository.PostOrder(order);

            return o;


        }

    }
}
