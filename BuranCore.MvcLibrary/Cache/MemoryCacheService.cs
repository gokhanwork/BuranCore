using Buran.Core.Library.Reflection;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Buran.Core.MvcLibrary.Cache
{
    public class MemoryCacheService : IMemoryCacheService
    {
        protected readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private void DeleteCache<T>() where T : class
        {
            string key = typeof(T).Name;
            _memoryCache.Remove(key);
        }

        public List<T> GetList<T>() where T : class
        {
            List<T> cacheList = default;
            string key = typeof(T).Name;
            _memoryCache.TryGetValue(key, out cacheList);

            return cacheList;
        }

        public T GetItem<T>(int id) where T : class
        {
            var list = GetList<T>();
            T entry = default;
            entry = list.AsQueryable().Where($"Id=={id}").FirstOrDefault();
            return entry;
        }

        public void Insert<T>(T item) where T : class
        {
            var list = GetList<T>();
            list.Add(item);
            DeleteCache<T>();
            Load(list);
        }

        public void Load<T>(List<T> value) where T : class
        {
            string key = typeof(T).Name;
            _memoryCache.Set(key, value, new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.NeverRemove,
            });
        }

        public void RemoveItem<T>(T item) where T : class
        {
            var list = GetList<T>();

            var a = Digger.GetObjectValue(item, "Id");
            var removeItem = list.AsQueryable().Where($"Id=={a}").FirstOrDefault();
            list.Remove(removeItem);
            DeleteCache<T>();
            Load(list);
        }

        public void Update<T>(T item) where T : class
        {
            RemoveItem(item);
            Insert(item);
        }
    }
}
