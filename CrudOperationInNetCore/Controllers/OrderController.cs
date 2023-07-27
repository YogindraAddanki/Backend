using Microsoft.AspNetCore.Mvc;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;




namespace CrudOperationInNetCore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BrandContext _dbContext;

        public OrderController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {

            if (_dbContext.Orders == null)
            {
                return NotFound();
            }
            return await _dbContext.Orders.ToArrayAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {

            if (_dbContext.Orders == null)
            {
                return NotFound();
            }
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }



        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);


        }

    }
}
