using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Models;
using Order.Queries.Interfaces;

namespace Order.Queries.Handlers
{
    public class OrderQuery : IOrderQuery
    {
        AppDbContext _db;
        private readonly IMapper _mapper;

        public OrderQuery(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<List<OrderQueryModel>> GetAllOrder(OrderQueryModel model)
        {
            var orders = await _db.Orders.Where(x => x.IsOrderConfirmed == model.IsOrderConfirmed 
            && x.CustomerId == model.CustomerId).ToListAsync();

            var result = _mapper.Map<List<OrderQueryModel>>(orders);
            return result;
        }

        public async Task<List<OrderQueryModel>> GetOrderById(OrderQueryModel model)
        {
            var orders = await _db.Orders.Where(x=> x.IsOrderConfirmed == model.IsOrderConfirmed
            && x.CustomerId== model.CustomerId 
            && x.OrderId == model.OrderId).ToListAsync();

            var result = _mapper.Map<List<OrderQueryModel>>(orders);
            return result;
        }
    }
}
