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
        public string FileName { get; }
        public WorkingWithFile(string fileName)
        {
            FileName = fileName;
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
            if (!File.Exists(_path))
                throw new FileNotFoundException();

            using var file = new FileStream(_path, FileMode.Open);
            using var stream = new StreamReader(file, Encoding.UTF8);

            var readItem = stream.ReadToEnd();

            return string.IsNullOrEmpty(readItem) ? Array.Empty<T>()  
                : JsonSerializer.Deserialize<IEnumerable<T>>(readItem);
        }
    }
}
