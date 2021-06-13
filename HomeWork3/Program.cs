using FoodOrdering.Data;
using FoodOrdering.Models;
using FoodOrdering.Services;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrdering
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var filePath = "JsonStore.json";
            var workingWithFile = new WorkingWithFile<Product>(filePath);
            var productsStore = new ProductsStore(workingWithFile);
            productsStore.InitializeProducts();

            var workingWithAPI = new WorkingWithAPI<ExchangeRateInfo>("https://api.privatbank.ua/p24api/exchange_rates?json&date=13.06.2021");
            var exchangeRateService = new ExchangeRateService(workingWithAPI);
            await exchangeRateService.InitializeAsync();

            var messageService = new ConsoleService();
            var productService = new ProductService(productsStore);
            var validationService = new ValidationService(productsStore);
            var logger = new Logger(@"D:\TestFolder");
            var orderSystem = new OrderSystem("SameDelivery", messageService, productService, validationService, logger, exchangeRateService);

            orderSystem.Start();  
        }
    }
}
