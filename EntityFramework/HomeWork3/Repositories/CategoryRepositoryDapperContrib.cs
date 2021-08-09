using Dapper.Contrib.Extensions;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Сontracts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FoodOrderingSystem.Repositories
{
    class CategoryRepositoryDapperContrib : ICategoryRepository
    {
        private IDbConnection _dbConnection;
        public CategoryRepositoryDapperContrib(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public List<Category> GetAllCategories()
        {
            return _dbConnection.GetAll<Category>().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbConnection.Get<Category>(id);
        }

        public void InsertCategory(Category category)
        {
            _dbConnection.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            _dbConnection.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            _dbConnection.Delete(category);
        }
    }
}
