using FoodOrdering.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.Services
{
    public class ExchangeRateService
    {
        public ExchangeRateInfo ExchangeRateInfo { get; set; }
        private readonly WorkingWithAPI<ExchangeRateInfo> _workingWithAPI;

        public ExchangeRateService(WorkingWithAPI<ExchangeRateInfo> workingWithAPI) 
        {
            _workingWithAPI = workingWithAPI;
        }
        public async Task InitializeAsync() 
        {
            ExchangeRateInfo = await _workingWithAPI.GetInstanceAsync();
        }
        public IEnumerable<ExchangeRate> GetExchangeRates() 
        {
            return ExchangeRateInfo.exchangeRate;
        }
        public decimal ChangeCurrency(decimal convertedNumber, string currencyTo) 
        {
            return convertedNumber / GetExchangeRate(currencyTo).purchaseRateNB;
        }
        public ExchangeRate GetExchangeRate(string currency) 
        {
            return ExchangeRateInfo.exchangeRate.Where(rate => rate.currency == currency.ToUpper()).FirstOrDefault();
        }

    }
}
