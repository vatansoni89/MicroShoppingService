using Order.Models;

namespace Order.Queries.Interfaces
{
    public interface IOrderQuery
    {
        Task<List<OrderQueryModel>> GetOrderById(OrderQueryModel model);
        Task<List<OrderQueryModel>> GetAllOrder(OrderQueryModel model);
    }
}
