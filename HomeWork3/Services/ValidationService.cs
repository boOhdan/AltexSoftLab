using FoodOrdering.BLL.Contracts;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FoodOrdering.BLL.Services
{
    public class ValidationService : IValidationService
    {
        public string  AddressPattern { get; } = @"^(ул\.|улица)\s?\w+(.|,)\s?(д\.|дом)\s?\d+(\,\s?(кв\.|квартира)\s?\d+\.?)?$";
        public string NumberPattern { get; } = @"^(\+380(\(\d{2}\)|\d{2})|0\d{2})\s?\d{3}\s?\d{2}\s?\d{2}$";

        public bool IsAddressValid(string address) 
        {
            return Regex.IsMatch(address, AddressPattern);
        }
        public bool IsNumberValid(string number)
        {
            return Regex.IsMatch(number, NumberPattern);
        }
    }
}
