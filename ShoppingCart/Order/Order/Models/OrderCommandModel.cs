namespace Order.Models
{
    public class OrderCommandModel
    {
        public int CustomerId { get; set; }
        public int ProducuId { get; set; }
        public virtual int OrderId { get; set; }
    }
}
