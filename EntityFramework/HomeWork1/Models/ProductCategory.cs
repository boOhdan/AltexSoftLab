using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class ProductCategory
    {
        public string Name;

        public IEnumerable<Product> ProductCategories { get; set; }
    }
}
