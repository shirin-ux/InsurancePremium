using Microsoft.EntityFrameworkCore;
using PremiumAccountService.Application.IRepository;
using PremiumAccountService.Domain.Entities;
using PremiumAccountService.Infrastructure.Context;

namespace PremiumAccountService.Infrastructure.InsuranceRepository
{
    public class InsuranceRepository() : IInsuranceRepository
    {

        private readonly InsuranceDbContext _context;

        public async Task AddInsuranceRequest(InsuranceRequest insuranceRequest)
        {

            _context.AddAsync(insuranceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InsuranceRequest>> GetAllInsuranceRequests()
        {
            return await _context.InsuranceRequests.Select(x => new InsuranceRequest
            {
                Amount = x.Amount,
               TotalPremium=x.TotalPremium,
                Title = x.Title,
                Coverages = x.Coverages.Select(c => new Coverage
                {
                    Id = c.Id,
                    PremiumRate=c.PremiumRate,
                    MaxAmount=c.MaxAmount,
                    MinAmount=c.MinAmount,
                    InsuranceRequestId=c.InsuranceRequestId,
                    Type = c.Type
                }).ToList()
            }).ToListAsync();
        }

        public async Task<List<Coverage>> GetCoverages() => await _context.coverages.ToListAsync();

    

    }
}
