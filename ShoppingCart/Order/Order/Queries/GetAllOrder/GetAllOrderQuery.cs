using MediatR;

namespace Order.Queries.GetAllOrder
{
    public class GetAllOrderQuery : IRequest<List<GetOrderQueryResponse>>
    {
        public int CustomerId { get; set; }
    }
}
