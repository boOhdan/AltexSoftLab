using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Customer : User
    {
        public List<Order> Orders { get; set; }
    }
}
