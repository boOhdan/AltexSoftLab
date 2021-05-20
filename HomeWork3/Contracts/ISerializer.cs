using System.Collections.Generic;

namespace FoodOrdering.Contracts
{
    public interface ISerializer<T>
    {
        void SerializeElementsAndSaveToFile<T>(IEnumerable<T> elements);
        IEnumerable<T> DeserializeElementsFromFile<T>();
    }
}
