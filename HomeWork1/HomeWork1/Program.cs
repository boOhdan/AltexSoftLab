using System;

namespace HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWork homeWork = new HomeWork();

            Console.WriteLine(homeWork.InvokePriceCalculatiion());
            Console.ReadKey();
        }
    }
}
