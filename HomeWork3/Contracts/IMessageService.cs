using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering
{
    public interface IMessageService
    {
        bool SendMessage(string message);
        string ReceiveMessage();
    }
}
