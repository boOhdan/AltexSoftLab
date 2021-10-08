using Dapper.Contrib.Extensions;

namespace FoodOrderingSystem.Models
{
    [Table("Products")]
    public class Product
    {
        [ExplicitKey]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
    }
}
