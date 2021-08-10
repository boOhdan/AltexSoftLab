using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Rate
    {
        public decimal Price { get; set; }

        public List<Order> Orders { get; set; }
    }
}
