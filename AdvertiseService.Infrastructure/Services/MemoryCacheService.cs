using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace AdvertiseService.Infrastructure.Services
{
    public interface ICacheService

    {

        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null);

    }

    public class MemoryCacheService : ICacheService

    {

        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)

        {

            _cache = cache;

        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null)

        {

            return await _cache.GetOrCreateAsync(key, async entry =>

            {

                entry.AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(5);

                return await factory();

            });

        }

    }
}
