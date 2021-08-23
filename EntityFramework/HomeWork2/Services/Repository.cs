using FoodOrderingSystem.Date;
using FoodOrderingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrderingSystem.Services
{
    public class Repository
    {
        private readonly AppStore _appStore;

        public Repository(AppStore appStore) 
        {
            _appStore = appStore;
        }

        public IEnumerable<Product> SortProductsAlphabetically() 
        {
            return _appStore.Products.OrderBy(product => product.Name);
        }
        public IEnumerable<(string SupplierName, string ProductName)> GetProductsWithTheirSuppliers()
        {
            return 
                _appStore.Suppliers
                .SelectMany(supplier => supplier.Products, (supplier, product) =>
                    (
                        SupplierName: supplier.Name,
                        ProductName: product.Name
                    )
                );
        }
        public IEnumerable<(string CategoryName, int CategoryNumber)> GetCategoriesWithProductsNumberInIt()
        {
            return 
                _appStore.Products
                .SelectMany(product => product.ProductCategories)
                .GroupBy(category => category.Name, (categoryName, categories) =>
                    (
                        CategoryName: categoryName,
                        CategoryNumber: categories.Count()
                    )
                );
        }

        public IEnumerable<(string SupplierName, int ProductNumber)> SortInDescendingSuppliersByProductNumber()
        {
            return 
                _appStore.Suppliers
                .SelectMany(supplier => supplier.Products, (supplier, product) =>
                    (
                        SupplierName: supplier.Name,
                        Product: product
                    )
                )
                .GroupBy(result => result.SupplierName, (supplierName, products) =>
                    
                    (
                        SupplierName: supplierName,
                        ProductNumber: products.Count()
                    )
                )
                .OrderByDescending(result => result.ProductNumber);
        }

        public IEnumerable<Product> GetCommonSuppliersProducts(int supplierId1, int supplierId2)
        {
            return
                _appStore.Suppliers[supplierId1].Products
                .Intersect(_appStore.Suppliers[supplierId2].Products);
        }

        public IEnumerable<Product> GetUniqueSuppliersProducts(int supplierId1, int supplierId2)
        {
            return
                _appStore.Suppliers[supplierId1].Products
                .Except(_appStore.Suppliers[supplierId2].Products);
        }

    }
}
