using Order.Models;

namespace Order.Commands.Interfaces
{
    public interface IOrderCommand
    {
        Task<OrderCommandModel> AddOrderAsync(OrderCommandModel model);
        Task<bool> UpdateOrderAsync(OrderCommandModel model);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> ConfirmOrderAsync(OrderCommandModel model);
    }
}
