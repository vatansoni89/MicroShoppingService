using MediatR;
using Shipping.Entities;

namespace Shipping.CQRS.Queries.EventHandlers.Created
{
    public class CreatedShipment : Shipment, IRequest<int>
    {
    }
}
