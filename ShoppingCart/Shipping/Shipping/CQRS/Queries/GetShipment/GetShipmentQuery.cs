using MediatR;
using Shipping.Entities;

namespace Shipping.CQRS.Queries.GetShipment
{
    public class GetShipmentQuery : IRequest<Shipment>
    {
        public string ShipmentId { get; set; }
        public GetShipmentQuery(string shipmentId)
        {
            ShipmentId = shipmentId ?? throw new ArgumentNullException(nameof(shipmentId));
        }
    }
}
