using FoodOrderingSystem.Models;
using System.Collections.Generic;

namespace FoodOrderingSystem.Сontracts
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        List<Category> GetAll();
        void Insert(Category category);
        void Update(Category category);
        void DeleteById(int categoryId);
    }
}
