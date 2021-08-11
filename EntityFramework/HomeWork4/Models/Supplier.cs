using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Product> Products { get; set; }
    }
}
