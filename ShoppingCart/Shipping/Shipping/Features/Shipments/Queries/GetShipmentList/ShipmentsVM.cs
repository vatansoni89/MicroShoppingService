namespace Shipping.Features.Shipments.Queries.GetShipmentList
{
    public class ShipmentsVM
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime ShippedDateUtc { get; set; }
        public DateTime DeliveryDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
