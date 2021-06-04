using FoodOrdering.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FoodOrdering.Services
{
    public class WorkingWithFile<T> : IWorkingWithFile<T>
    {
        private readonly string _path;

        public WorkingWithFile(string fileName)
        {
            _path = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }

        public void WriteAndSaveElementsToOverwrittenFile(IEnumerable<T> elements)
        {
            var serialized = JsonSerializer.Serialize(elements);

            using var file = new FileStream(_path, FileMode.Create);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.WriteLine(serialized);
        }

        public IEnumerable<T> ReadElementsFromFile()
        {
            using var file = new FileStream(_path, FileMode.OpenOrCreate);
            using var stream = new StreamReader(file, Encoding.UTF8);

            var item = stream.ReadToEnd();

            return item != "" ? JsonSerializer.Deserialize<IEnumerable<T>>(item) : new List<T>();
        }
    }
}
