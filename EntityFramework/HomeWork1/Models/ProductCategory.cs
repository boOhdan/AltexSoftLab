using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId {get; set;}
        public string Name { get; set; }

        public List<Product> ProductCategories { get; set; }
    }
}
