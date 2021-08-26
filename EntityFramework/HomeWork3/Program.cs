using FoodOrderingSystem.Models;
using FoodOrderingSystem.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace FoodOrderingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var config = Initialization();

            var categoryRepositoryDapper = new CategoryRepositoryDapper(config.GetConnectionString("DefaultConnection"));
            var categoryRepositoryDapperContrib = new CategoryRepositoryDapperContrib(config.GetConnectionString("DefaultConnection"));

            //сохранение сущности без вложенных объектов (Dapper)

            categoryRepositoryDapper.InsertCategory(new Category { CategoryId = 1, Name = "Vegetables" });
            categoryRepositoryDapper.InsertCategory(new Category { CategoryId = 2, Name = "Fruits" });

            //сохранение сущности с вложенными объектами (Dapper)
            categoryRepositoryDapper.InsertCategoryWithEmbeddedObjects(new Category
            {
                CategoryId = 3,
                Name = "Biscuits",
                Products = new()
                {
                    new()
                    {
                        ProductId = 1,
                        Name = "Blue Riband",
                        Description = "Blue Riband Blue Riband",
                        Price = 123,
                        Quantity = 23
                    },
                    new()
                    {
                        ProductId = 2,
                        Name = "Loacker",
                        Description = "Loacker Loacker",
                        Price = 67,
                        Quantity = 34
                    }
                }
            });

            categoryRepositoryDapper.InsertCategoryWithEmbeddedObjects(new Category
            {
                CategoryId = 4,
                Name = "Cakes",
                Products = new()
                {
                    new()
                    {
                        ProductId = 3,
                        Name = "Betty Crocker",
                        Description = "Betty Crocker Betty Crocker",
                        Price = 45,
                        Quantity = 12
                    },
                    new()
                    {
                        ProductId = 4,
                        Name = "Loacker",
                        Description = "Krispy Kreme Krispy Kreme",
                        Price = 56,
                        Quantity = 22
                    }
                }
            });

            //выборка всех сущностей без вложенных объектов (Dapper)

            Console.WriteLine("выборка всех сущностей без вложенных объектов (Dapper)");

            var categories1 = categoryRepositoryDapper.GetAllCategories();

            foreach (var category in categories1)
            {
                Console.WriteLine($"CategoryID: {category.CategoryId} - CategoryName: {category.Name}");
            }

            //выборка всех сущностей с вложенными объектами (Dapper)

            Console.WriteLine("выборка всех сущностей с вложенными объектами (Dapper)");

            var categories2 = categoryRepositoryDapper.GetAllCategoriesWithEmbeddedObjects();

            foreach (var category in categories2)
            {
                Console.WriteLine($"CategoryID: {category.Value.CategoryId} - CategoryName: {category.Value.Name}");

                foreach (var product in category.Value.Products)
                {
                    Console.WriteLine($"    ProductID: {product.ProductId} - ProductName: {product.Name} - Price: {product.Price} - Quantity: {product.Quantity}");
                }
            }

            //поиск сущности по Id без вложенных объектов (Dapper)

            Console.WriteLine("поиск сущности по Id без вложенных объектов (Dapper)");

            var category1 = categoryRepositoryDapper.GetCategoryById(1);

            Console.WriteLine($"CategoryID: {category1.CategoryId} - CategoryName: {category1.Name}");

            //поиск сущности по Id с вложенными объектами (Dapper)

            Console.WriteLine("поиск сущности по Id c вложенных объектов (Dapper)");

            var category3 = categoryRepositoryDapper.GetCategoryByIdWithEmbeddedObjects(3);

            Console.WriteLine($"CategoryID: {category3.CategoryId} - CategoryName: {category3.Name}");

            foreach (var product in category3.Products)
            {
                Console.WriteLine($"    ProductID: {product.ProductId} - ProductName: {product.Name} - Price: {product.Price} - Quantity: {product.Quantity}");
            }

            //обновление сущности без вложенных объектов (Dapper)

            categoryRepositoryDapper.UpdateCategory(new Category { CategoryId = 2, Name = "Fruits (UPDATED)" });

            //обновление сущности с вложенными объектами (Dapper)

            categoryRepositoryDapper.UpdateCategoryWithEmbeddedObjects(new Category
            {
                CategoryId = 4,
                Name = "Cakes (UPDATED)",
                Products = new()
                {
                    new()
                    {
                        ProductId = 3,
                        Name = "Betty Crocker (UPDATED)",
                        Description = "Betty Crocker Betty Crocker (UPDATED)",
                        Price = 45,
                        Quantity = 12
                    },
                    new()
                    {
                        ProductId = 4,
                        Name = "Loacker (UPDATED)",
                        Description = "Krispy Kreme Krispy Kreme (UPDATED)",
                        Price = 56,
                        Quantity = 22
                    }
                }
            });

            //удаление сущности без вложенных объектов (Dapper)

            categoryRepositoryDapper.DeleteCategory(new Category { CategoryId = 2, Name = "Fruits (UPDATED)" });

            //удаление сущности c вложенных объектов (Dapper)

            categoryRepositoryDapper.DeleteCategoryWithEmbeddedObjects(new Category { CategoryId = 4, Name = "Cakes (UPDATED)" });

            //сохранение сущности без вложенных объектов(DapperContib)

            categoryRepositoryDapperContrib.InsertCategory(new Category { CategoryId = 5, Name = "Meats" });
            categoryRepositoryDapperContrib.InsertCategory(new Category { CategoryId = 6, Name = "Frozen foods" });

            //выборка всех сущностей без вложенных объектов (DapperContib)

            Console.WriteLine("выборка всех сущностей без вложенных объектов (DapperContib)");

            var categories3 = categoryRepositoryDapperContrib.GetAllCategories();

            foreach (var category in categories3)
            {
                Console.WriteLine($"CategoryID: {category.CategoryId} - CategoryName: {category.Name}");
            }

            //поиск сущности по Id без вложенных объектов (DapperContib)

            Console.WriteLine("поиск сущности по Id без вложенных объектов (DapperContib)");

            var category4 = categoryRepositoryDapperContrib.GetCategoryById(1);

            Console.WriteLine($"CategoryID: {category4.CategoryId} - CategoryName: {category4.Name}");

            //обновление сущности без вложенных объектов(DapperContib)

            categoryRepositoryDapperContrib.UpdateCategory(new Category { CategoryId = 5, Name = "Meats (UPDATED)" });

            //удаление сущности без вложенных объектов (DapperContib)

            categoryRepositoryDapperContrib.DeleteCategory(new Category { CategoryId = 6 });
        }

        static IConfiguration Initialization() 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}
