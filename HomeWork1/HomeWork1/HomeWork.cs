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

            // Your solution supposed to be here.

            var _prices = prices.ToArray();
            var _destinations = destinations.ToArray();
            var _currencies = currencies.ToArray();
            var _clients = clients.ToArray();
            string street;

            if (_prices.Length != _currencies.Length || _currencies.Length != _clients.Length)
                throw new Exception("Prices, currencies, clients have the different lengths");

            for(var i = 0; i < _destinations.Length; i++)
            {
                street = getStreet(_destinations[i]);

                if (_currencies[i] == "EUR")
                {
                    _prices[i] *= 1.19m;
                    _currencies[i] = "USD";
                }

                if (street == "Wayne Street")
                    _prices[i] += 10;

                else if (street == "North Heather Street")
                    _prices[i] -= 5.36m;

                if (childrenIds.Contains(i))
                    _prices[i] -= 0.25m * _prices[i];

                if (infantsIds.Contains(i)) 
                    _prices[i] -= 0.5m * _prices[i];

                if (i > 0)
                {
                    if (street == getStreet(_destinations[i - 1]))
                        _prices[i] -= 0.15m * _prices[i];
                }

            }

            fullPrice = _prices.Sum();

            // Your solution supposed to be here.

            return fullPrice;
        }

        public string getStreet(string destinations) 
        {
            string[] _destinations = destinations.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0]
                .Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return String.Join(' ', _destinations.Skip(1));
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
