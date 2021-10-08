using System;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodDeliveryCost homeWork = new FoodDeliveryCost();

            Console.WriteLine(homeWork.InvokePriceCalculatiion());
            Console.ReadKey();
        }
    }
}
