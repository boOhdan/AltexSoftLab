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

        public List<Category> GetAll()
        {
            return _dbConnection.GetAll<Category>().ToList();
        }

        public Category GetById(int id)
        {
            return _dbConnection.Get<Category>(id);
        }

        public void Insert(Category category)
        {
            _dbConnection.Insert(category);
        }

        public void Update(Category category)
        {
            _dbConnection.Update(category);
        }

        public void DeleteById(int categoryId)
        {
            var category = GetById(categoryId);

            _dbConnection.Delete(category);
        }
    }
}
