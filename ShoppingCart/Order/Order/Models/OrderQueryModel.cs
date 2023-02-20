using System.ComponentModel.DataAnnotations;

namespace Order.Models
{
    public class OrderQueryModel
    {
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Required]
        public bool IsOrderConfirmed { get; set; }
    }
}