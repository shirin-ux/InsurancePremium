using Microsoft.Extensions.Caching.Memory;
using PremiumAccountService.Domain.Entities;
using PremiumAccountService.Domain.IInMemoryCacheService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Infrastructure.InMemoryCacheService
{
    public class MemoryCoverageCacheService : IInMemoryCoverageCacheService
    {
        private readonly MemoryCache _cache;
        private const string CacheKey = "Coverage";
        public MemoryCoverageCacheService()
        {
                _cache=new MemoryCache(new MemoryCacheOptions());
        }
        public Task<List<Coverage>> GetCoveragesAsync()
        {
            _cache.TryGetValue(CacheKey, out List<Coverage> coverages);
            return Task.FromResult(coverages);
            
        }

        public Task SetAllCovergeAsync(List<Coverage> coverages)
        {
            _cache.Set(CacheKey, coverages, TimeSpan.FromHours(24));
            return Task.CompletedTask;
        }
    }
}
