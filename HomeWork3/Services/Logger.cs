using FoodOrdering.Contracts;
using FoodOrdering.Models;
using System;
using System.IO;
using System.Text;

namespace FoodOrdering.Services
{
    public class Logger : ILogger
    {
        private string FileDirectory { get; set; }

        public Logger(string filedirectory) 
        {
            FileDirectory = Directory.Exists(filedirectory) ? filedirectory : throw new DirectoryNotFoundException();
        }

        public void Append<T>(T element, OperationType operationStatus) 
        {
            var fileName = DateTime.Now.ToString("dddd, dd MMMM yyyy") + ".txt";

            using var file = new FileStream(Path.Combine(FileDirectory, fileName), FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.WriteLine($"date: {DateTime.Now}; operation: {operationStatus} {typeof(T).Name}; element: {element}");
        }
    }
}
