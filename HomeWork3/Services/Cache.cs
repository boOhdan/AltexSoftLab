using FoodOrdering.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering.BLL.Services
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
                    if (_cache.Count == _sizeLimit)
                        DeleteLastElement();

                    _cache[key] = createElement(key);
                }
            }
  
            return _cache[key];
        }

        public void DeleteLastElement() 
        {
            lock (_cacheLock) 
            {
                _cache.Remove(_cache.Keys.Last());
            }
        }
    }
}
