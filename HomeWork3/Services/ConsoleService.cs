using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Services
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
