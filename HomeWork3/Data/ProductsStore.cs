using FoodOrdering.Contracts;
using System.Collections.Generic;

namespace FoodOrdering.Data
{
    public class ProductsStore : IProductsStore
    {
        public ICollection<Product> Products { get; set; }
        private readonly ISerializer<Product> _jsonSerializer;

        public ProductsStore(ISerializer<Product> serializer) 
        {
            Products = new List<Product>();
            _jsonSerializer = serializer;
        }
        public void GetStorageContext()
        {
            Products = (ICollection<Product>)_jsonSerializer.DeserializeElementsFromFile<Product>();
        }

        public void SetStorageContext()
        {
            _jsonSerializer.SerializeElementsAndSaveToFile(Products);
        }
    }
}
