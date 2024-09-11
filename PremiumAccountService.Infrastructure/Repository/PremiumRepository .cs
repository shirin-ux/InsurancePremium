using Microsoft.EntityFrameworkCore;
using PremiumAccountService.Domain.Entities;
using PremiumAccountService.Infrastructure.Context;

namespace PremiumAccountService.Infrastructure.IInsuranceRepository
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PremiumDbContext _context;

        public async Task<List<Coverage>> GetCoveragesByIds(List<int> coverageIds) => await _context.coverages.Where(c => coverageIds.Contains(c.Id)).ToListAsync();
    }
}
