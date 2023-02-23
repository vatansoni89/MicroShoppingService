using MediatR;

namespace Shipping.CQRS.Commands.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteShipmentCommand(int id)
        {
            Id = id;
        }
    }
}
