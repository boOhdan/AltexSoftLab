using FoodOrdering.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.Services
{
    public class Cache<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly object _cacheLock = new object();
        private readonly int _sizeLimit;
        private Dictionary<TKey, TValue> _cache = new Dictionary<TKey, TValue>();

        public Cache(int sizeLimit = 5) 
        {
            _sizeLimit = sizeLimit > 0 ? sizeLimit : throw new ArgumentException();
        }

        public TValue GetOrCreate(TKey key, Func<TKey, TValue> createElement)
        {
            lock(_cacheLock) 
            {
                if (!_cache.ContainsKey(key))
                {
                    if (IsCacheFull())
                        DeleteLastElement();

                    _cache[key] = createElement(key);
                }
            }
  
            return _cache[key];
        }

        public bool IsCacheFull() 
        {
            return _cache.Count == _sizeLimit;
        }

        public void DeleteLastElement() 
        {
            _cache.Remove(_cache.Keys.Last());
        }
    }
}
