using FoodOrdering.Contracts;
using System.Collections.Generic;

namespace FoodOrdering.Data
{
    public class ProductsStore : IProductsStore
    {
        public ICollection<Product> Products { get; set; }
        private readonly IWorkingWithFile<Product> _workingWithFile;

        public ProductsStore(IWorkingWithFile<Product> workingWithFile) 
        {
            Products = new List<Product>();
            _workingWithFile = workingWithFile;
        }
        public void InitializeProducts()
        {
            Products = (ICollection<Product>)_workingWithFile.ReadElementsFromFile();
        }

        public void UpdateStorageContent()
        {
            _workingWithFile.WriteAndSaveElementsToOverwrittenFile(Products);
        }
    }
}
