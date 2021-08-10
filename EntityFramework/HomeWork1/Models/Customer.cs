using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Customer : User
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
