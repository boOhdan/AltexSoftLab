using System.Collections.Generic;

namespace FoodOrdering
{
    public class Business
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
