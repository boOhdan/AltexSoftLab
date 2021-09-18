using System.Threading.Tasks;

namespace FoodOrdering.BLL.Contracts
{
    public interface IWorkingWithAPI<T>
    {
        string Url { get; }

        Task<T> GetInstanceAsync();
    }
}
