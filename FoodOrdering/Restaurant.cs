using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering
{
    public class Restaurant
    {
        public string Name { get; set; }
        public ICollection<Meal> Menu { get; set; }
        public string Address { get; set; }
    }
}
