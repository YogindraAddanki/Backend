using CrudOperationInNetCore.Context;
using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;


namespace CrudOperationInNetCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly BrandContext _dbContext;

        public OrderRepository(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Order> GetAllOrders()
        {
            return _dbContext.Orders.ToArray();
        }

        public Order? GetOrderById(int id)
        {
           
                var o = _dbContext.Orders.Where(c => c.Id == id).FirstOrDefault();

                return o;
            
        }

        public Order PostOrder( Order order)
        {
            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();

          

            return order;
        }

        public Order? DeleteOrder(int id)
        {

            var o = _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();

            if (o != null)
            {

                _dbContext.Remove(o);

                _dbContext.SaveChanges();
            }

         

            return o;

        }

        public Order? PutOrder(int id,Order order)
        {
            var o = _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();

            if(o != null)
            {
                o.Name = order.Name;

                o.BrandId = order.BrandId;

                _dbContext.SaveChanges();

                return o;

            }

            return null;





        }
   
    }
}
