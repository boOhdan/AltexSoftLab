using FoodOrdering.Data;
using FoodOrdering.Services;
using System;
using System.Text;

namespace FoodOrdering
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var filePath = "JsonStore.json";
            var workingWithFile = new WorkingWithFile<Product>(filePath);
            var productsStore = new ProductsStore(workingWithFile);
            productsStore.InitializeProducts();

            var messageService = new ConsoleService();
            var productsCache = new Cache<int, Product>();
            var productService = new ProductService(productsStore, productsCache);
            var validationService = new ValidationService(productsStore);
            var logger = new Logger(@"D:\TestFolder");
            var orderSystem = new OrderSystem("SameDelivery", messageService, productService, validationService, logger, productsCache);

            orderSystem.Start();
        }
    }
}
