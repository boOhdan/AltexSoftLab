using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Supplier
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
