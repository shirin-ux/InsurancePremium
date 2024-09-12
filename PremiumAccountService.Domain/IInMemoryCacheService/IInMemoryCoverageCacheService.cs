using PremiumAccountService.Domain.Entities;

namespace PremiumAccountService.Domain.IInMemoryCacheService
{
    public interface IInMemoryCoverageCacheService
    {
        Task<List<Coverage>> GetCoveragesAsync();
        Task SetAllCovergeAsync(List<Coverage> coverages);
    }
}
