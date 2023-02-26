using MediatR;
using Shipping.Entities;

namespace Shipping.CQRS.Queries.GetShipment
{
    public class GetShipmentQuery : IRequest<Shipment>
    {
        public int ShipmentId { get; set; }
        public GetShipmentQuery(int shipmentId)
        {
            ShipmentId = shipmentId;
        }
    }
}
