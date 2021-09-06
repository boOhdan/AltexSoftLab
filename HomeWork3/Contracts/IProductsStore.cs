using System.Collections.Generic;

namespace FoodOrdering.BLL.Contracts
{
    public interface IProductsStore
    {
        ICollection<Product> Products { get; set; }
        void UpdateStorageContent();
        void InitializeProducts();
    }
}
