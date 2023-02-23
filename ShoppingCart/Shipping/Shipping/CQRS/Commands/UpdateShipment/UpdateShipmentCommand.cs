using EventBus.Events;
using MediatR;
using Shipping.CQRS.Commands.OrderShipment;

namespace Shipping.CQRS.Commands.UpdateShipment
{
    public class UpdateShipmentCommand : CreateShipmentCommand
    {
        public int Id { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }

    }
}
