using FoodOrdering.DAL.Date;

namespace FoodOrdering.DAL
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
