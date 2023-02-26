using MediatR;

namespace Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
