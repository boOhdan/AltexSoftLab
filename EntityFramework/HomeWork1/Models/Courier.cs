using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Courier : User
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
