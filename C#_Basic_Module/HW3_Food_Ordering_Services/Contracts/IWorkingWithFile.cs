using System.Collections.Generic;

namespace FoodOrdering.BLL.Contracts
{
    public interface IWorkingWithFile<T>
    {
        string FileName { get; }
        void WriteAndSaveElementsToOverwrittenFile(IEnumerable<T> elements);
        IEnumerable<T> ReadElementsFromFile();
    }
}
