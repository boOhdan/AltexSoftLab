using FoodOrdering.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering
{
    public class ProductService : IProductService
    {
        public ProductsStore ProductsStore { get; set; }

        public ProductService(ProductsStore products)
        {
            ProductsStore = products;
        }

        public IEnumerable<Product> AddProduct(Product product)
        {
            return ProductsStore.Products = ProductsStore.Products.Append(product);
        }

        public IDictionary<int, string> GetProductTypes()
        {
            return Enum.GetValues(typeof(ProductType))
                .Cast<ProductType>()
                .ToDictionary(a => (int)a, a => a.ToString());
        }

        public IDictionary<int, Product> GetProductsByType(ProductType productType)
        {
            return ProductsStore.Products.Select((product, index) => new { index, product })
                    .Where(a => a.product.Type == productType)
                    .ToDictionary(a => a.index, a => a.product);
        }

        public Product GetProductById(int id)
        {
            return ProductsStore.Products.ElementAt(id);
        }

        public Product ReduceProductQuantity(int id, int quantity) 
        {
            GetProductById(id).Quantity -= quantity;
            return GetProductById(id);
        }

        public IEnumerable<Product> DeleteProduct(int id) 
        {
            return ProductsStore.Products = ProductsStore.Products.Where(a => a != GetProductById(id));
        }
    }
}
