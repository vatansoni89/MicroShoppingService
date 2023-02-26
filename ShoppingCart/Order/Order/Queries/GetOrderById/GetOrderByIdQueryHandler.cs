using AutoMapper;
using MediatR;
using Order.Models;
using Order.Queries.GetAllOrder;
using Microsoft.EntityFrameworkCore;

namespace Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, List<GetOrderQueryResponse>>
    {
        private AppDbContext _db;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<GetOrderQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var allOrderForCustomer = await _db.Orders.Where(x => x.OrderId == request.OrderId).ToListAsync();
            return _mapper.Map<List<GetOrderQueryResponse>>(allOrderForCustomer);
        }
    }
}
