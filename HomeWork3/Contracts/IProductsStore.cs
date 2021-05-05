using System.Collections.Generic;


namespace FoodOrdering.Contracts
{
    public interface IProductsStore
    {
        ICollection<Product> Products { get; set; }
        void AddDefaultElements();
    }
}
