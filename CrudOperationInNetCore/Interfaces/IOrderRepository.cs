using CrudOperationInNetCore.Models;

namespace CrudOperationInNetCore.Interfaces
{
    public interface IOrderRepository
    {

        Order? GetOrderById(int id);

        IEnumerable<Order> GetAllOrders();

        Order PostOrder(Order order);   

        Order? DeleteOrder(int id);

        Order? PutOrder(int id,Order order);



    }
}
