using FoodOrdering.BLL.Contracts;
using FoodOrdering.BLL.FoodOrdering.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.BLL
{
    public class ProductService : IProductService
    {
        private readonly IProductsStore _productsStore;

        public ProductService(IProductsStore products)
        {
            _productsStore = products;
        }

        public IEnumerable<Product> AddProduct(Product product)
        {
            _productsStore.Products.Add(product);
            _productsStore.UpdateStorageContent();

            return _productsStore.Products;
        }

        public IEnumerable<Product> GetAllProducts() 
        {
            return _productsStore.Products;
        }
        public IDictionary<int, string> GetProductTypes()
        {
            return Enum.GetValues(typeof(ProductType))
                .Cast<ProductType>()
                .ToDictionary(a => (int)a, a => a.ToString());
        }

        public IDictionary<int, Product> GetProductsByType(ProductType productType)
        {
            return _productsStore.Products.Select((product, index) => new { index, product })
                    .Where(a => a.product.Type == productType)
                    .ToDictionary(a => a.index, a => a.product);
        }

        public Product GetProductById(int id)
        {
            return _productsStore.Products.ElementAt(id);
        }

        public Product ReduceProductQuantity(int id, int quantity) 
        {
            GetProductById(id).Quantity -= quantity;
            return GetProductById(id);
        }

        public IEnumerable<Product> DeleteProduct(int id) 
        {
            _productsStore.Products.Where(a => a != GetProductById(id));
            _productsStore.UpdateStorageContent();

            return _productsStore.Products;
        }
    }
}
