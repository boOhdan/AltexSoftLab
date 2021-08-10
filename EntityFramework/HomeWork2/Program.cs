using FoodOrderingSystem.Date;
using FoodOrderingSystem.Services;
using System;
using System.Text;

namespace FoodOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var appStore = new AppStore();
            var repository = new Repository(appStore);

            //Task 1
            Console.WriteLine("\n1) Список всех продуктов, отсортированный в алфавитном порядке\n");

            foreach (var item in repository.SortProductsAlphabetically())
            {
                Console.WriteLine(item.Name);
            }

            //Task 2
            Console.WriteLine("\n2) Список всех продуктов с указанием поставщиков\n");

            foreach (var item in repository.GetProductsWithTheirSuppliers())
            {
                Console.WriteLine("{0} - {1}", item.SupplierName, item.ProductName);
            }

            //Task 3
            Console.WriteLine("\n3) Список категорий с указанием количества продуктов в нём\n");

            foreach (var item in repository.GetCategoriesWithProductsNumberInIt())
            {
                Console.WriteLine("{0} - {1}", item.CategoryName, item.CategoryNumber);
            }

            //Task 4
            Console.WriteLine("\n4) Список поставщиков, отсортированный в порядке убывания количества поставляемых ими продуктов\n");

            foreach (var item in repository.SortInDescendingSuppliersByProductNumber())
            {
                Console.WriteLine("{0} - {1}", item.SupplierName, item.ProductNumber);
            }

            //Task 5.1
            Console.WriteLine("\n5.1) Список продуктов, которые поставляются Igor и Bohdan\n");

            foreach (var item in repository.GetCommonSuppliersProducts(0, 1))
            {
                Console.WriteLine(item.Name);
            }

            //Task 5.2
            Console.WriteLine("\n5.2) Список продуктов, которые поставляются только Igor, не Bohdan\n");

            foreach (var item in repository.GetUniqueSuppliersProducts(0, 1))
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
