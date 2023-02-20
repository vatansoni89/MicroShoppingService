using MediatR;
using Shipping.Entities;

namespace Shipping.CQRS.Queries.GetShipmentList
{
    public class GetShipmentListQuery : IRequest<List<Shipment>>
    {
        public string? OrderId { get; set; }
        public GetShipmentListQuery() { }
        public GetShipmentListQuery(string orderId)
        {
            OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        }
    }
}
