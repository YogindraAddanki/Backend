using CrudOperationInNetCore.Models;

namespace CrudOperationInNetCore.Interfaces
{
    public interface IOrderRepository
    {

        IEnumerable<Order> GetOrders(Order order);

        Order GetOrder(int id);

        Order PostOrder(Order order);   



    }
}
