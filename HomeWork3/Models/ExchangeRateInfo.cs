using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FoodOrdering.Models
{
    public class ExchangeRateInfo
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("baseCurrency")]
        public decimal BaseCurrency { get; set; }

        [JsonPropertyName("baseCurrencyLit")]
        public string BaseCurrencyLit { get; set; }

        [JsonPropertyName("exchangeRate")]
        public IEnumerable<ExchangeRate> ExchangeRate { get; set; }
        public override string ToString()
        {
            return string.Format("date: {0}; bank: {1}; baseCurrency: {2}, baseCurrencyLit: {3}",
                Date, Bank, BaseCurrency, BaseCurrencyLit);
        }
    }
}
