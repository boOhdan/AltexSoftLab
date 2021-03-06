using System;
using System.Collections.Generic;

namespace FoodOrdering.DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string Address { get; set; }
        public decimal FullPrice { get; set; }
        public OrderStatus Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
