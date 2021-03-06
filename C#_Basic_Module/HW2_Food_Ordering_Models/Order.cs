using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        public OrderStatus Status { get; set; }
        public OrderSystem System { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
