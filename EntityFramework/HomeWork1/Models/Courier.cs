using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Courier : User
    {
        public int CourierId { get; set; }

        public List<Order> Orders { get; set; }
    }
}
