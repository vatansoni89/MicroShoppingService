using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shipping.Entities
{
    public class Shipment
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string OrderId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string TrackingNumber { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string TrackingUrl { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ShippedDateUtc { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DeliveryDateUtc { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedOnUtc { get; set; }
    }
}
