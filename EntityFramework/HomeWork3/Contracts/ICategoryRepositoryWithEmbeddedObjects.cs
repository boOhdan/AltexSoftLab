using FoodOrderingSystem.Models;
using System.Collections.Generic;

namespace FoodOrderingSystem.Сontracts
{
    public interface ICategoryRepositoryWithEmbeddedObjects
    {
        Category GetByIdWithEmbeddedObjects(int id);
        Dictionary<int, Category> GetAllWithEmbeddedObjects();
        void InsertWithEmbeddedObjects(Category category);
        void UpdateWithEmbeddedObjects(Category category);
        void DeleteWithEmbeddedObjects(Category category);
    }
}
