using FoodOrdering.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Services
{
    public class ValidationService
    {
        private readonly ProductsStore _productsStore;

        public ValidationService(ProductsStore products)
        {
            _productsStore = products;
        }

        public bool IsSuchTypeExist(int id) 
        {
            return Enum.IsDefined(typeof(ProductType), id); 
        }
        public bool IsSuchProductExist(int id)
        {
            return IsPositiveNumber(id) && _productsStore.Products.Count() > id;
        }
        public bool IsTheraAnyProductWithSuchType(ProductType productType) 
        {
            return _productsStore.Products.Where(a => a.Type == productType).Any();
        }
        public bool HasSystemEnoughProducts(int id, int quantity) 
        { 
            return _productsStore.Products.ElementAt(id).Quantity >= quantity; 
        }
        public bool IsProductHasSuchType(int id, ProductType type) 
        {
            return _productsStore.Products.ElementAt(id).Type == type;
        }
        public bool IsPositiveNumber(decimal element) 
        { 
            return element >= 0; 
        }
        public bool IsProductsNotEmpty()
        {
            return _productsStore.Products.Count() > 0;
        }
    }
}
