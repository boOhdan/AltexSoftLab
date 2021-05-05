using FoodOrdering.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.Data
{
    public class ProductsStore : IProductsStore
    {
        public IEnumerable<Product> Products { get; set; }

        public ProductsStore(IEnumerable<Product> products = null) 
        {
            Products = products ?? Enumerable.Empty<Product>();
        }
        public IEnumerable<Product> AddDefaultElements()
        {
            return Products = Products.Concat(new List<Product>()
                {
                    new Product("Toast", "Toast...", 12, ProductType.Breads, 5),
                    new Product("Corn", "Corn...", 13, ProductType.Cereals, 12),
                    new Product("Wheat", "Wheat...", 17, ProductType.Cereals, 23),
                    new Product("Pizza", "Pizza...", 23, ProductType.Breads, 12),
                    new Product("Beef", "Beef...", 160, ProductType.Meat, 23),
                });
        }
    }
}
