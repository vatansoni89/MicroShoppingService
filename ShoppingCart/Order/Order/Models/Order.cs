namespace Order.Models
{
    public class Order
    {
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsOrderConfirmed { get; set; }
        public virtual int OrderId { get; set; }
    }
}
