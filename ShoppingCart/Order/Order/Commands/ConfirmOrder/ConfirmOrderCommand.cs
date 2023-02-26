using MediatR;

namespace Order.Commands.ConfirmOrder
{
    public class ConfirmOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}
