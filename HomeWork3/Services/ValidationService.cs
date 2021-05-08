using FoodOrdering.Contracts;
using FoodOrdering.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoodOrdering.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IProductsStore _productsStore;

        public ValidationService(IProductsStore products)
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
        public bool IsAddressValid(string address) 
        {
            var pattern = @"^(ул\.|улица)\s?\w+(.|,)\s?(д\.|дом)\s?\d+(\,\s?(кв\.|квартира)\s?\d+\.?)?$";

            if (Regex.IsMatch(address, pattern))
                return true;

            return false;
        }
        public bool IsNumberValid(string number)
        {
            var pattern = @"^(\+380(\(\d{2}\)|\d{2})|0\d{2})\s?\d{3}\s?\d{2}\s?\d{2}$";

            if (Regex.IsMatch(number, pattern))
                return true;

            return false;
        }
    }
}
