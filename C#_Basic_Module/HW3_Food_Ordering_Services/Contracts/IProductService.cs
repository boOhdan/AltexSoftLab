using FoodOrdering.DAL.Models;
using System.Collections.Generic;

namespace FoodOrdering.BLL.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product GetById(int id);
        void Insert(Product product);
        void Delete(int id);
        void Delete(Product product);
        void Update(Product product);
        void Save();
    }
}
