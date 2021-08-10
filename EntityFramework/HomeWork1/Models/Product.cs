using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
