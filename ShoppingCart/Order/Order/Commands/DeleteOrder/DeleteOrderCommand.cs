using MediatR;

namespace Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}
