using MediatR;

namespace Shipping.CQRS.Queries.EventHandlers.Deleted
{
    public class DeletedShipment : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
