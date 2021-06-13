using System;

namespace FoodOrdering.Models
{
    public class ExchangeRate
    {
        public string baseCurrency { get; set; }
        public string currency { get; set; }
        public decimal saleRateNB { get; set; }
        public decimal purchaseRateNB { get; set; }
        public decimal saleRate { get; set; }
        public decimal purchaseRate { get; set; }
        public override string ToString()
        {
            return String.Format("baseCurrency: {0}; currency: {1}; saleRateNB: {2}, purchaseRateNB: {3}; saleRate: {4}; purchaseRate: {5}",
                baseCurrency, currency, saleRateNB, purchaseRateNB, saleRate, purchaseRate);
        }
    }
}
