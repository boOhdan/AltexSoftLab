using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Customer : User
    {
        public int CustomerId { get; set; }

        public List<Order> Orders { get; set; }
    }
}
