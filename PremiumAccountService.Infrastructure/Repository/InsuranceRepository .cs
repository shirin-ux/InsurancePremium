using Microsoft.EntityFrameworkCore;
using PremiumAccountService.Application.IRepository;
using PremiumAccountService.Domain.Entities;
using PremiumAccountService.Infrastructure.Context;

namespace PremiumAccountService.Infrastructure.InsuranceRepository
{
    public class InsuranceRepository : IInsuranceRepository
    {

        private readonly InsuranceDbContext _context;
        public InsuranceRepository(InsuranceDbContext context)
        {
            _context = context;
        }
        public async Task AddInsuranceRequest(InsuranceRequest insuranceRequest)
        {
            _context.AddAsync(insuranceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InsuranceRequest>> GetAllInsuranceRequests()
        {
            return await _context.InsuranceRequests.Include(x=>x.RequestCoverages).ThenInclude(c=>c.Coverage).ToListAsync();
        }

        public async Task<List<Coverage>> GetCoverages() => await _context.coverages.ToListAsync();

    

    }
}
