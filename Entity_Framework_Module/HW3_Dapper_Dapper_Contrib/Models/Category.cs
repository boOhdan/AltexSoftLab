using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace FoodOrderingSystem.Models
{
    [Table("Categories")]
    public class Category
    {
        [ExplicitKey]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        [Write(false)]
        [Computed]
        public List<Product> Products { get; set; }
    }
}
