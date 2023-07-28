using CrudOperationInNetCore.Models;

namespace CrudOperationInNetCore.Interfaces
{
    public interface IOrderRepository
    {

        Order GetOrderById(int id);

        IEnumerable<Order> GetAllOrders();

        Order PostOrder(Order order);   



    }
}
