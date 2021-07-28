using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
