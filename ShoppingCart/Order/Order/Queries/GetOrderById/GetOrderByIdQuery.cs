using MediatR;
using Order.Queries.GetAllOrder;

namespace Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<List<GetOrderQueryResponse>>
    {
        public int OrderId { get; set; }
    }
}
