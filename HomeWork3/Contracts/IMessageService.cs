using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering
{
    public interface IMessageService
    {
        public bool SendMessage(string message);
        public string ReceiveMessage();

    }
}
