using FoodOrdering.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FoodOrdering.Services
{
    public class JsonSerialization<T> : ISerializer<T>
    {
        private string Path { get; set; }

        public JsonSerialization(string fileName)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;
        }

        public void SerializeElementsAndSaveToFile<T>(IEnumerable<T> elements)
        {
            var serialized = JsonSerializer.Serialize(elements);

            using var file = new FileStream(Path, FileMode.Create);
            using var stream = new StreamWriter(file, Encoding.UTF8);

            stream.WriteLine(serialized);
        }

        public IEnumerable<T> DeserializeElementsFromFile<T>()
        {
            using var file = new FileStream(Path, FileMode.OpenOrCreate);
            using var stream = new StreamReader(file, Encoding.UTF8);

            var item = stream.ReadToEnd();

            return item != "" ? JsonSerializer.Deserialize<IEnumerable<T>>(item) : new List<T>();
        }
    }
}
