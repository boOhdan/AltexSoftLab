using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Rate
    {
        public decimal Price { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
