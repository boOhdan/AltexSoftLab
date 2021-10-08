using System.Text.Json.Serialization;

namespace FoodOrdering.DAL.Models
{
    public class ExchangeRate
    {
        [JsonPropertyName("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("saleRateNB")]
        public decimal SaleRateNB { get; set; }

        [JsonPropertyName("purchaseRateNB")]
        public decimal PurchaseRateNB { get; set; }

        [JsonPropertyName("saleRate")]
        public decimal SaleRate { get; set; }

        [JsonPropertyName("purchaseRate")]
        public decimal PurchaseRate { get; set; }
        public override string ToString()
        {
            return string.Format("baseCurrency: {0}; currency: {1}; saleRateNB: {2}, purchaseRateNB: {3}; saleRate: {4}; purchaseRate: {5}",
                BaseCurrency, Currency, SaleRateNB, PurchaseRateNB, SaleRate, PurchaseRate);
        }
    }
}
