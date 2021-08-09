using FoodOrderingSystem.Models;
using System.Collections.Generic;

namespace FoodOrderingSystem.Сontracts
{
    public interface ICategoryRepositoryWithEmbeddedObjects
    {
        Category GetCategoryByIdWithEmbeddedObjects(int id);
        Dictionary<int, Category> GetAllCategoriesWithEmbeddedObjects();
        void InsertCategoryWithEmbeddedObjects(Category category);
        void UpdateCategoryWithEmbeddedObjects(Category category);
        void DeleteCategoryWithEmbeddedObjects(Category category);
    }
}
