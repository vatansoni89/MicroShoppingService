using MediatR;
using Order.Models;

namespace Order.Commands.ConfirmOrder
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, bool>
    {
        private AppDbContext _db;

        public ConfirmOrderCommandHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _db.Orders.FirstOrDefault(x => x.OrderId == request.OrderId);

                //Shipping flow, returns true if success or false
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
