using System.ComponentModel.DataAnnotations;

namespace Order.Models
{
    public class OrderQueryModel
    {
        public int CustomerId { get; set; }
        public int ProducuId { get; set; } 
        public virtual int OrderId { get; set; }
    }
}