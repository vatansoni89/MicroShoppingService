using Shipping.Entities;

namespace Shipping.Repositories.Interfaces
{
    public interface IShipmentRepository
    {
        Task<List<Shipment>> GetShipments();
        Task<Shipment> GetShipment(string id);
        Task<List<Shipment>> GetShipmentsByOrderId(string orderId);
        Task CreateShipment(Shipment Shipment);
        Task<bool> UpdateShipment(Shipment Shipment);
        Task<bool> DeleteShipment(string id);
    }
}
