using FoodOrdering.Models;

namespace FoodOrdering.Contracts
{
    public interface ILogger
    {
        void Append<T>(T element, OperationType operationStatus);
    }
}
