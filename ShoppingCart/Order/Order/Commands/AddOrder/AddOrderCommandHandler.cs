using AutoMapper;
using MediatR;
using Order.Models;
using Order.Queries.GetAllOrder;

namespace Order.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Order.Queries.GetAllOrder.GetOrderQueryResponse>
    {
        AppDbContext _db;
        private readonly IMapper _mapper;

        public AddOrderCommandHandler(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GetOrderQueryResponse> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order.Models.Order
            {
                CustomerId = request.CustomerId,
                ProducuId = request.ProducuId
            };
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return _mapper.Map<GetOrderQueryResponse>(order);
        }
    }
}
