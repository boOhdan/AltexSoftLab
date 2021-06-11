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

            ProductsStore productsStore = new ProductsStore();
            productsStore.AddDefaultElements();

            var messageService = new ConsoleService();
            var productService = new ProductService(productsStore);
            var validationService = new ValidationService(productsStore);
            var logger = new Logger(@"D:\TestFolder");
            var productCache = new Cache<int, Product>();
            var orderSystem = new OrderSystem("SameDelivery", messageService, productService, validationService, logger, productCache);

            orderSystem.Start();
        }
    }
}
