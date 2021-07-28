using System;
using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Order
    {
        public DateTime OrderedDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string Address { get; set; }
        public decimal FullPrice { get; set; }
        public OrderStatus Status { get; set; }
        public Rate Rate { get; set; }
        public Customer Customer { get; set; }
        public Courier Courier { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
