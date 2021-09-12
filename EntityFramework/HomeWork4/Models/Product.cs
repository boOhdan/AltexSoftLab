using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Unspecified product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unspecified product description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Unspecified product price")]
        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Unspecified product quantity")]
        [Range(1, 1000, ErrorMessage = "Value should be greater than 1 or less than 1000")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Unspecified supplier id")]
        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int? SupplierId { get; set; }

        [Required(ErrorMessage = "Unspecified category id")]
        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int? ProductCategoryId { get; set; }

        public Supplier Supplier { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
