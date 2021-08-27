using FoodOrderingSystem.Date;

namespace FoodOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodOrderingContext = new FoodOrderingContext();
            foodOrderingContext.Database.EnsureCreated();
        }
    }
}
