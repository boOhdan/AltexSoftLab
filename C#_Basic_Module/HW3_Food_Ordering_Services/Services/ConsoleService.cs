using FoodOrdering.BLL.Contracts;
using System;

namespace FoodOrdering.BLL.Services
{
    public class ConsoleService : IMessageService
    {
        public bool SendMessage(string message)
        {
            if (message is null)
                return false;

            Console.WriteLine(message);
            return true;
        }
        public string ReceiveMessage()
        {
            return Console.ReadLine();
        }
    }
}
