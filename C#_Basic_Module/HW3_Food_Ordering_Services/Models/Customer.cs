using System.Collections.Generic;

namespace FoodOrdering
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
