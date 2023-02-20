using Shipping.Entities;

namespace Shipping.Repositories.Interfaces
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<Shipment>> GetShipments();
        Task<Shipment> GetShipment(string id);
        Task<Shipment> GetShipmentByOrderId(string orderId);
        Task CreateShipment(Shipment Shipment);
        Task<bool> UpdateShipment(Shipment Shipment);
        Task<bool> DeleteShipment(string id);
    }
}
