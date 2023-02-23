using MediatR;
using Shipping.Entities;

namespace Shipping.CQRS.Queries.EventHandlers.Updated
{
    public class UpdatedShipment : Shipment, IRequest<bool>
    {

    }
}
