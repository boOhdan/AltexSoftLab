using System.Collections.Generic;


namespace FoodOrdering
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> AddProduct(Product product);
        IDictionary<int, string> GetProductTypes();
        IDictionary<int, Product> GetProductsByType(ProductType productType);
        Product GetProductById(int id);
        Product ReduceProductQuantity(int id, int quantity);
    }
}
