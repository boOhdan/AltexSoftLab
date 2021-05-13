using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Contracts
{
    public interface IValidationService
    {
        bool IsSuchTypeExist(int id);
        bool IsSuchProductExist(int id);
        bool IsTheraAnyProductWithSuchType(ProductType productType);
        bool HasSystemEnoughProducts(int id, int quantity);
        bool IsProductHasSuchType(int id, ProductType type);
        bool IsPositiveNumber(decimal element);
        bool IsProductsNotEmpty();
        bool IsNumberValid(string number);
        bool IsAddressValid(string address);
    }
}
