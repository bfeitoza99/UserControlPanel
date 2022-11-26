using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using UserControlPanel.CrossCutting.DependencyInjection;
using UserControlPanel.Domain.Interfaces.Service;

namespace UserControlPanel.Application.Service
{
    [Injectable(typeof(ICacheManagerService))]
    public class CacheManagerService : ICacheManagerService
    {
        private readonly IMemoryCache _cache;

        private readonly MemoryCacheEntryOptions _options;

        public CacheManagerService(IMemoryCache cache)
        {
            _cache = cache;
            _options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                SlidingExpiration = TimeSpan.FromMinutes(30)
            };
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Set(string key, object value)
        {
             _cache.Set(key, value, _options);
        }
    }
}
