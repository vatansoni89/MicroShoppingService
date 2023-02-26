using MediatR;
using Order.Models;

namespace Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private AppDbContext _db;

        public DeleteOrderCommandHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _db.Orders.FirstOrDefault(x => x.OrderId == request.OrderId);

                if (order != null)
                {
                    _db.Orders.Remove(order);
                    await _db.SaveChangesAsync(CancellationToken.None);
                    return true;
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
