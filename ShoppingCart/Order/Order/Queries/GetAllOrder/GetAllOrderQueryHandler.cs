using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Order.Models;

namespace Order.Queries.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<GetOrderQueryResponse>>
    {
        private AppDbContext _db;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<GetOrderQueryResponse>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var allOrderForCustomer = await _db.Orders.Where(x => x.CustomerId == request.CustomerId).ToListAsync();
            return _mapper.Map<List<GetOrderQueryResponse>>(allOrderForCustomer);
        }
    }
}
