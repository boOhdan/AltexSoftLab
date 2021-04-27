using System.Collections.Generic;


namespace FoodOrdering.Contracts
{
    public interface IProductsStore
    {
        IEnumerable<Product> Products { get; set; }
        IEnumerable<Product> AddDefaultElements();
    }
}
