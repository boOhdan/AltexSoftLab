using System;
using System.Collections.Generic;
using System.Linq;


namespace HomeWork1
{
    internal class HomeWork
    {
        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;

            var pricesArray = prices.ToArray();
            var destinationsArray = destinations.ToArray();
            var currenciesArray = currencies.ToArray();
            var clientsArray = clients.ToArray();
            string street;

            if (pricesArray.Length != currenciesArray.Length 
                || currenciesArray.Length != clientsArray.Length 
                || clientsArray.Length != destinationsArray.Length) 
            {
                throw new Exception("Prices, currencies, clients have the different lengths");
            }

            for(var i = 0; i < destinationsArray.Length; i++)
            {
                street = GetStreetName(destinationsArray[i]);

                if (currenciesArray[i] == "EUR")
                {
                    pricesArray[i] *= 1.19m;
                    currenciesArray[i] = "USD";
                }

                if (street == "Wayne Street")
                    pricesArray[i] += 10;

                else if (street == "North Heather Street")
                    pricesArray[i] -= 5.36m;

                if (childrenIds.Contains(i))
                    pricesArray[i] -= 0.25m * pricesArray[i];

                if (infantsIds.Contains(i)) 
                    pricesArray[i] -= 0.5m * pricesArray[i];

                if (i > 0)
                {
                    if (street == GetStreetName(destinationsArray[i - 1]))
                        pricesArray[i] -= 0.15m * pricesArray[i];
                }

            }

            fullPrice = pricesArray.Sum();

            return fullPrice;
        }

        public string GetStreetName(string destination) 
        {
            string[] address = destination.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return String.Join(' ', address.Skip(1));
        }

        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
}
