using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn.Tools
{
    public sealed class ObjCache
    {
        private static readonly ObjCache _instance = new ObjCache();

        private ObjCache() { }
        static ObjCache() { }

        public static ObjCache Instance { get { return _instance; } }

        public ObjectCache cache = MemoryCache.Default;

        public T Get<T>(string key)
        {
            if (cache.Contains(key))
                return (T)cache[key];

            return default(T);
        }

        public void Set<T>(string key, T value, int expireInMinutes)
        {
            cache.Set(key, value, DateTime.Now.AddMinutes(expireInMinutes));
        }

        public bool HasCache(string key)
        {
            return cache.Contains(key);
        }
    }
}
