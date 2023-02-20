using EventBus.Events;
using MediatR;

namespace Shipping.CQRS.Commands.OrderShipment
{
    public class OrderShipmentCommand : IRequest<string>
    {
        public string OrderId { get; set; }
        public DateTime ShippedDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime DeliveryDateUtc { get; set; }
    }
}
