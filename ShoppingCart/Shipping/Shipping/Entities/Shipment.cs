using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Entities
{
    public class Shipment
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string OrderId { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string TrackingNumber { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string TrackingUrl { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ShippedDateUtc { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? DeliveryDateUtc { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedOnUtc { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastModifiedOnUtc { get; set; }
    }
}
