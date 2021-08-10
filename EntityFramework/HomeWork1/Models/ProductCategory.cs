using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class ProductCategory
    {
        public string Name;

        public List<Product> ProductCategories { get; set; }
    }
}
