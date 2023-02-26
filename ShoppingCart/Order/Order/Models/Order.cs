namespace Order.Models
{
    public class Order
    {
        public int CustomerId { get; set; }
        public int ProducuId { get; set; }
        public virtual int OrderId { get; set; }
    }
}
