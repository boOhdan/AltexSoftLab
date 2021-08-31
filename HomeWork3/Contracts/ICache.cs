using System;

namespace FoodOrdering.Contracts
{
    public interface ICache<TKey, TValue>
    {
        TValue GetOrCreate(TKey key, Func<TKey, TValue> createElement);
        void DeleteLastElement();
    }
}
