using FoodOrdering.BLL.Contracts;
using FoodOrdering.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.BLL.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        public ExchangeRateInfo ExchangeRateInfo { get; set; }
        private readonly IWorkingWithAPI<ExchangeRateInfo> _workingWithAPI;

        public ExchangeRateService(IWorkingWithAPI<ExchangeRateInfo> workingWithAPI) 
        {
            _workingWithAPI = workingWithAPI;
        }
        public async Task InitializeAsync() 
        {
            ExchangeRateInfo = await _workingWithAPI.GetInstanceAsync();
        }
        public IEnumerable<ExchangeRate> GetExchangeRates() 
        {
            return ExchangeRateInfo.ExchangeRate;
        }
        public decimal ChangeCurrency(decimal convertedNumber, string currencyTo) 
        {
            return convertedNumber / GetExchangeRate(currencyTo).PurchaseRateNB;
        }
        public ExchangeRate GetExchangeRate(string currency) 
        {
            return ExchangeRateInfo.ExchangeRate.Where(rate => rate.Currency == currency.ToUpper()).FirstOrDefault();
        }

    }
}
