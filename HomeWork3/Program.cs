using FoodOrdering.Data;
using FoodOrdering.Services;

namespace FoodOrdering
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductsStore productsStore = new ProductsStore();
            productsStore.AddDefaultElements();

            var messageService = new ConsoleService();
            var productService = new ProductService(productsStore);
            var validationService = new ValidationService(productsStore);
            var orderSystem = new OrderSystem("SameDelivery", messageService, productService, validationService);

            orderSystem.Start();
        }
    }
}
