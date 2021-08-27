namespace FoodOrdering.BLL.Contracts
{
    public interface ILogger
    {
        void Append<T>(T element, string operationStatus);
    }
}
