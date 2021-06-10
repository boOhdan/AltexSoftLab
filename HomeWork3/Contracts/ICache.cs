using System;

namespace FoodOrdering.Contracts
{
    public interface ICache<TKey, TValue>
    {
        public TValue GetOrCreate(TKey key, Func<TKey, TValue> createElement);

        public bool IsCacheFull();

        public void DeleteLastElement();
    }
}
