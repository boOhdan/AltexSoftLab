using System.Collections.Generic;

namespace FoodOrdering.Contracts
{
    public interface IWorkingWithFile<T>
    {
        void WriteAndSaveElementsToOverwrittenFile(IEnumerable<T> elements);
        IEnumerable<T> ReadElementsFromFile();
    }
}
