using System.Collections.Generic;

namespace FoodOrdering.Contracts
{
    public interface ISerializer<T>
    {
        void SerializeElementsAndSaveToFile(IEnumerable<T> elements);
        IEnumerable<T> DeserializeElementsFromFile();
    }
}
