using MediatR;

namespace Shipping.Features.Shipments.Commands.DeleteShipment
{
    public class DeleteShipmentCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
