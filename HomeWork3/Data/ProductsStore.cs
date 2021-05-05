using FoodOrdering.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.Data
{
    public class ProductsStore : IProductsStore
    {
        public ICollection<Product> Products { get; set; }

        public ProductsStore(IList<Product> products = null) 
        {
            Products = products ?? new List<Product>();
        }
        public void AddDefaultElements()
        {
            Products.Add(new Product("Toast", "Toast...", 12, ProductType.Breads, 5));
            Products.Add(new Product("Corn", "Corn...", 13, ProductType.Cereals, 12));
            Products.Add(new Product("Wheat", "Wheat...", 17, ProductType.Cereals, 23));
            Products.Add(new Product("Pizza", "Pizza...", 23, ProductType.Breads, 12));
            Products.Add(new Product("Beef", "Beef...", 160, ProductType.Meat, 23));
        }
    }
}
