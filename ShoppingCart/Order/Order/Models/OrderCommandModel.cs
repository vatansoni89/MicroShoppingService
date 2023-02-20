﻿namespace Order.Models
{
    public class OrderCommandModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsOrderConfirmed { get; set; }
    }
}
