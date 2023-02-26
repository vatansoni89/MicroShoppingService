using Shipping.Entities;

namespace Shipping.Repositories.Interfaces
{
    public interface IShipmentReadRepository
    {
        Task<List<Shipment>> GetShipments();
        Task<Shipment> GetShipment(int id);
        Task<List<Shipment>> GetShipmentsByOrderId(string orderId);
    }
}
