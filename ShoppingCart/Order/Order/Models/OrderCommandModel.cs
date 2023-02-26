using MediatR;

namespace Order.Models
{
    public class OrderCommandModel : IRequest<bool>
    {
        public int CustomerId { get; set; }
        public int ProducuId { get; set; }
        public virtual int OrderId { get; set; }
    }
}
