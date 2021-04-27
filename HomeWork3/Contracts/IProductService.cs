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
        public IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> AddProduct(Product product);
        IDictionary<int, string> GetProductTypes();
        IDictionary<int, Product> GetProductsByType(ProductType productType);
        Product GetProductById(int id);
        Product ReduceProductQuantity(int id, int quantity);
    }
}
