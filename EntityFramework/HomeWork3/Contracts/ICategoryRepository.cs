using FoodOrderingSystem.Models;
using System.Collections.Generic;

namespace FoodOrderingSystem.Сontracts
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
