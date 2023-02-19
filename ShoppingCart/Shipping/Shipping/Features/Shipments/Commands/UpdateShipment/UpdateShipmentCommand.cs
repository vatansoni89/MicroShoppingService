using EventBus.Events;
using MediatR;

namespace Shipping.Features.Shipments.Commands.UpdateShipment
{
    public class UpdateShipmentCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime ShippedDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
