using Dapper;
using FoodOrderingSystem.Models;
using FoodOrderingSystem.Сontracts;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FoodOrderingSystem.Repositories
{
    public class CategoryRepositoryDapper : ICategoryRepository, ICategoryRepositoryWithEmbeddedObjects
    {
        private IDbConnection _dbConnection;
        public CategoryRepositoryDapper(string connectionString) 
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public Dictionary<int, Category> GetAllWithEmbeddedObjects()
        {
            var categoryDictionary = new Dictionary<int, Category>();

            var sql = "SELECT * FROM Categories AS C LEFT JOIN Products AS P ON C.CategoryID = P.CategoryID";

            var list = _dbConnection.Query<Category, Product, Category>(
                sql,
                (category, product) => 
                {
                    Category categoryEntry;

                    if (!categoryDictionary.TryGetValue(category.CategoryId, out categoryEntry))
                    {
                        categoryEntry = category;
                        categoryEntry.Products = new List<Product>();
                        categoryDictionary.Add(categoryEntry.CategoryId, categoryEntry);
                    }

                    if(product is not null)
                        categoryEntry.Products.Add(product);

                    return categoryEntry;
                }, 
                splitOn: "ProductID")
                .Distinct()
                .ToList();

            return categoryDictionary;
        }

        public Category GetByIdWithEmbeddedObjects(int id)
        {
            Category categoryEntry = null;

            var sql = $"SELECT * FROM Categories AS C LEFT JOIN Products AS P ON C.CategoryID = P.CategoryID WHERE C.CategoryID ={id}";

            var list = _dbConnection.Query<Category, Product, Category>(
                sql,
                (category, product) => 
                {
                    if (categoryEntry is null) 
                    {
                        categoryEntry = category;
                        categoryEntry.Products = new List<Product>();
                    }

                    if (product is not null)
                        categoryEntry.Products.Add(product);

                    return category;
                }, 
                splitOn: "ProductID")
                .Distinct()
                .ToList();

            return categoryEntry;
        }

        public void InsertWithEmbeddedObjects(Category category)
        {
            var sqlInsertCategory = $"INSERT INTO Categories VALUES('{category.CategoryId}', '{category.Name}')";

            _dbConnection.Query(sqlInsertCategory);

            foreach (var product in category.Products) 
            {
                var sqlInsertProduct = $"INSERT INTO Products VALUES({product.ProductId}, '{product.Name}', '{product.Description}', {product.Price}, {product.Quantity}, {category.CategoryId})";
                
                _dbConnection.Query(sqlInsertProduct);
            }
        }

        public void UpdateWithEmbeddedObjects(Category category)
        {
            var sqlUpdateCategory = $"UPDATE Categories SET Name = @CategoryName WHERE CategoryID = @CategoryID";

            _dbConnection.Execute(sqlUpdateCategory, new { CategoryID = category.CategoryId, CategoryName = category.Name});

            foreach (var product in category.Products)
            {
                var sqlUpdateProduct = $"UPDATE Products SET Name = @ProductName, Description = @Description, Price = @Price, Quantity = @Quantity WHERE ProductID = @ProductID";

                _dbConnection.Execute(sqlUpdateProduct, new { ProductID = product.ProductId, ProductName = product.Name, Description = product.Description, Price = product.Price, Quantity = product.Quantity });
            }
        }

        public void DeleteWithEmbeddedObjects(Category category)
        {
            var sqlDeleteProduct = $"DELETE FROM Products WHERE CategoryID = {category.CategoryId}";

            _dbConnection.Query(sqlDeleteProduct);

            var sqlDeleteCategory = $"DELETE FROM Categories WHERE CategoryID = {category.CategoryId}";

            _dbConnection.Query(sqlDeleteCategory);
        }

        public Category GetById(int id)
        {
            var sql = $"SELECT * FROM Categories WHERE CategoryID = {id}";

            return _dbConnection.QueryFirstOrDefault<Category>(sql);
        }

        public List<Category> GetAll()
        {
            var sql = $"SELECT * FROM Categories";

            return _dbConnection.Query<Category>(sql).ToList();
        }

        public void Insert(Category category)
        {
            var sql = $"INSERT INTO Categories VALUES({category.CategoryId}, '{category.Name}')";

            _dbConnection.Query(sql);
        }

        public void Update(Category category)
        {
            var sql = $"UPDATE Categories SET Name = '{category.Name}' WHERE CategoryID = {category.CategoryId}";

            _dbConnection.Query(sql);
        }

        public void Delete(Category category)
        {
            var sql = $"DELETE FROM Categories WHERE CategoryID = {category.CategoryId}";

            _dbConnection.Query(sql);
        }
    }
}
