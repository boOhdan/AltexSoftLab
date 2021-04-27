using FoodOrdering.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering
{
    public interface IProductService
    {
        public ProductsStore ProductsStore { get; set; }
        public IEnumerable<Product> AddProduct(Product product);
        public IDictionary<int, string> GetProductTypes();
        public IDictionary<int, Product> GetProductsByType(ProductType productType);
        public Product GetProductById(int id);
        public Product ReduceProductQuantity(int id, int quantity);
    }
}
