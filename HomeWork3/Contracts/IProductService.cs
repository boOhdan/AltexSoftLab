﻿using System.Collections.Generic;

namespace FoodOrdering.BLL.Contracts
{
    public interface IProductService
    {

        int GetProductsCount();
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> AddProduct(Product product);
        IDictionary<int, string> GetProductTypes();
        IDictionary<int, Product> GetProductsByType(ProductType productType);
        Product GetProductById(int id);
        Product ReduceProductQuantity(int id, int quantity);
    }
}
