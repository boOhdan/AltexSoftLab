using System.Threading.Tasks;

namespace FoodOrdering.Contracts
{
    public interface IWorkingWithAPI<T>
    {
        string Url { get; }

        Task<T> GetInstanceAsync();
    }
}
