using MediatR;


namespace Shipping.Features.Shipments.Queries.GetShipmentList
{
    public class GetShipmentListQuery : IRequest<List<ShipmentsVM>>
    {
        public string OrderId { get; set; }

        public GetShipmentListQuery(string orderId)
        {
            OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
        }
    }
}
