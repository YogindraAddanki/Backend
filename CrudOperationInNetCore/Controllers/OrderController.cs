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
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            Array array = (Array)_orderRepository.GetAllOrders();

            if (array.Length == 0)
            {
                return NotFound();
            }
            return Ok(array);

        }


        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {

            Order? order = _orderRepository.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }



        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            Order o = _orderRepository.PostOrder(order);

            return o;


        }

        [HttpDelete("{id}")]

        public ActionResult<Order> DeleteOrder(int id)
        {

            var order = _orderRepository.DeleteOrder(id);

            if (order == null)
                return NotFound();

            return Ok(order);


        }


        [HttpPut]

        public ActionResult<Order> PutOrder(int id, Order order)
        {

            var ordercreated = _orderRepository.PutOrder(id, order);

            if (ordercreated == null)
                return NotFound();

            return ordercreated;

        }

    }
}
