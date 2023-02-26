using MediatR;
using Order.Models;

namespace Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private AppDbContext _db;

        public UpdateOrderCommandHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _db.Orders.FirstOrDefault(x => x.OrderId == request.OrderId);

                if (order != null)
                {
                    order.ProducuId = request.ProductId;
                    _db.Orders.Update(order);
                    var numberOfEntries = await _db.SaveChangesAsync();
                    if (numberOfEntries > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}