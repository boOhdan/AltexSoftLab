using FoodOrdering.BLL.Contracts;
using System;
using System.IO;
using System.Text;

namespace FoodOrdering.BLL.Services
{
    public class Logger : ILogger
    {
        private readonly string _fileDirectory;

        public Logger(string filedirectory) 
        {
            _fileDirectory = Directory.Exists(filedirectory) ? filedirectory : throw new DirectoryNotFoundException();
        }

        public void Append<T>(T element, string operationStatus) 
        {
            var fileName = "logs_" + DateTime.Now.ToString("MMddyyyy") + ".txt";

            using var file = new FileStream(Path.Combine(_fileDirectory, fileName), FileMode.Append);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.WriteLine($"date: {DateTime.Now}; operation: {operationStatus} {typeof(T).Name}; element: {element}");
        }
    }
}
