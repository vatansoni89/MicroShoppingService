namespace EventBus.Events
{
    public class OrderShipmentEvent
    {
        public string OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime DeliveryDateUtc { get; set; }
        public DateTime ShippedDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
