using EventBus.Events;
using MediatR;

namespace Shipping.CQRS.Commands.OrderShipment
{
    public class CreateShipmentCommand : IRequest<int>
    {
        public string OrderId { get; set; }
        public DateTime ShippedDateUtc { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingUrl { get; set; }
    }
}
