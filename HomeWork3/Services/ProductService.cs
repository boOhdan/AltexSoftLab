using FoodOrdering.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering
{
    public class ProductService : IProductService
    {
        private readonly IProductsStore _productsStore;
        private readonly ICache<int, Product> _productsCache;

        public ProductService(IProductsStore products, ICache<int, Product> productsCache)
        {
            _productsStore = products;
            _productsCache = productsCache;
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
        public int GetProductsCount() 
        {
            return _productsStore.Products.Count;
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
            return _productsCache.GetOrCreate(id, (productId) => _productsStore.Products
                                                            .Where(product => product.Id == productId)
                                                            .FirstOrDefault());
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
