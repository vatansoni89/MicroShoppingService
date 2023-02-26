using MediatR;

namespace Order.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<Order.Queries.GetAllOrder.GetOrderQueryResponse>
    {
        public int CustomerId { get; set; }
        public int ProducuId { get; set; }
    }
}
