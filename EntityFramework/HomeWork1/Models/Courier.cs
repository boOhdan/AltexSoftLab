using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Courier : User
    {
        public List<Order> Orders { get; set; }
    }
}
