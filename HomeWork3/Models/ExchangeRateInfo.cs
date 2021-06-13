using System;
using System.Collections.Generic;

namespace FoodOrdering.Models
{
    public class ExchangeRateInfo
    {
        public string date { get; set; }
        public string bank { get; set; }
        public decimal baseCurrency { get; set; }
        public string baseCurrencyLit { get; set; }
        public IEnumerable<ExchangeRate> exchangeRate { get; set; }
        public override string ToString()
        {
            return String.Format("date: {0}; bank: {1}; baseCurrency: {2}, baseCurrencyLit: {3}",
                date, bank, baseCurrency, baseCurrencyLit);
        }
    }
}
