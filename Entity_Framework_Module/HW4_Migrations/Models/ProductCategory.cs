using System.Collections.Generic;

namespace FoodOrdering.DAL.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId {get; set;}
        public string Name { get; set; }

        public List<Product> ProductCategories { get; set; }
    }
}
