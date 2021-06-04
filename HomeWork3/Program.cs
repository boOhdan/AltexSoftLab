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

            var workingWithFile = new WorkingWithFile<Product>("JsonStore.json");
            ProductsStore productsStore = new ProductsStore(workingWithFile);
            productsStore.InitializeProducts();

            var messageService = new ConsoleService();
            var productService = new ProductService(productsStore);
            var validationService = new ValidationService(productsStore);
            var logger = new Logger(@"D:\TestFolder");
            var orderSystem = new OrderSystem("SameDelivery", messageService, productService, validationService, logger);

            orderSystem.Start();
        }
    }
}
