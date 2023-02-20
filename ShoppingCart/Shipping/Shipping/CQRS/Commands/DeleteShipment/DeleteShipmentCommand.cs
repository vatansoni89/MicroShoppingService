using MediatR;

namespace Shipping.CQRS.Commands.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest<string>
    {
        public string Id { get; set; }
        public DeleteShipmentCommand(string id)
        {
            Id = id;
        }
    }
}
