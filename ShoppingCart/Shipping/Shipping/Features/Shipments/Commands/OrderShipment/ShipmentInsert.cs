namespace Shipping.Features.Shipments.Commands.OrderShipment
{
    public class ShipmentInsert
    {
        public string OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime ShippedDateUtc { get; set; }
        public DateTime DeliveryDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
