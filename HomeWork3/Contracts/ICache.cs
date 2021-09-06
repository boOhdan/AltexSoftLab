using System;

namespace FoodOrdering.BLL.Contracts
{
    public interface ICache<TKey, TValue>
    {
        TValue GetOrCreate(TKey key, Func<TKey, TValue> createElement);
        void DeleteLastElement();
    }
}
