using FoodOrdering.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodOrdering.BLL.Contracts
{
    public interface IExchangeRateService
    {
        ExchangeRateInfo ExchangeRateInfo { get; set; }
        Task InitializeAsync();
        IEnumerable<ExchangeRate> GetExchangeRates();
        decimal ChangeCurrency(decimal convertedNumber, string currencyTo);
        ExchangeRate GetExchangeRate(string currency);
    }
}
