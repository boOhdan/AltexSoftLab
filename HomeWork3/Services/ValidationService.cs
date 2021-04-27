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
        public ProductsStore ProductsStore { get; set; }

        public ValidationService(ProductsStore products)
        {
            ProductsStore = products;
        }

        public bool IsSuchTypeExist(int id) 
        {
            return Enum.IsDefined(typeof(ProductType), id); 
        }
        public bool IsSuchProductExist(int id)
        {
            return IsPositiveNumber(id) && ProductsStore.Products.Count() > id;
        }
        public bool IsTheraAnyProductWithSuchType(ProductType productType) 
        {
            return ProductsStore.Products.Where(a => a.Type == productType).Any();
        }
        public bool HasSystemEnoughProducts(int id, int quantity) 
        { 
            return ProductsStore.Products.ElementAt(id).Quantity >= quantity; 
        }
        public bool IsProductHasSuchType(int id, ProductType type) 
        {
            return ProductsStore.Products.ElementAt(id).Type == type;
        }
        public bool IsPositiveNumber(decimal element) 
        { 
            return element >= 0; 
        }
        public bool IsProductsNotEmpty()
        {
            return ProductsStore.Products.Count() > 0;
        }
    }
}
