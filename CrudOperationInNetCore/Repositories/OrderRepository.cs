using CrudOperationInNetCore.Interfaces;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

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

        public Order GetOrderById(int id)
        {
           
                var o = _dbContext.Orders.Where(c => c.Id == id).FirstOrDefault();

                return (Order)o;
            
        }

        public Order PostOrder( Order order)
        {
            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();

          

            return order;
        }

   
    }
}
