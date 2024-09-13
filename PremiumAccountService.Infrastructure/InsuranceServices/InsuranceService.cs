using Microsoft.EntityFrameworkCore;
using PremiumAccountService.Application.DTO;
using PremiumAccountService.Application.IInsuranceServices;
using PremiumAccountService.Application.IRepository;
using PremiumAccountService.Domain.Entities;
using PremiumAccountService.Domain.IInMemoryCacheService;

namespace PremiumAccountService.Infrastructure.InsuranceServices
{
    public class InsuranceService(IInsuranceRepository insuranceRepository, IInMemoryCoverageCacheService memoryCoverageCacheService) : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository = insuranceRepository;
        private readonly IInMemoryCoverageCacheService _memoryCoverageCacheService = memoryCoverageCacheService;

        public async Task<decimal> AddInsuranceRequest(InsuranceRequestDto request)
        {
            var insuranceRequest = new InsuranceRequestDto
            {
                Title = request.Title,
                RequestCoverage = new List<InsuranceRequestCoverageDto>(),
                Amount=request.Amount,
                Coverage=new List<CoverageDto>()
            };
            decimal totalPremium = 0;

            foreach (var coverage in request.Coverage)
            {
                totalPremium += await CalculatePremiumAsync(coverage.Type, request.Amount);
                var requestCoverage = new InsuranceRequestCoverageDto
                {
                    Type = coverage.Type,
                    CoverageId = await GetCoverageById(coverage.Type), 
                    PaymentAmount = totalPremium
                };
                insuranceRequest.RequestCoverage.Add(requestCoverage);

            }
            await _insuranceRepository.AddInsuranceRequest(new InsuranceRequest
            {
                Title = insuranceRequest.Title,
                RequestCoverages = insuranceRequest.RequestCoverage.Select(x => new InsuranceRequestCoverage
                {
                    CoverageId = x.CoverageId,
                    PayementAmount =x.PaymentAmount
                }).ToList(),
                Amount=insuranceRequest.Amount
            });
            return totalPremium;
        }

        public async Task<decimal> CalculatePremiumAsync(int typeCoverage, decimal amount)
        {
            var coverages = await GetCoverage();
            var coverage = coverages.Where(c => c.Type == typeCoverage).FirstOrDefault();

            if (coverage == null)
            {
                throw new ArgumentException("پوشش نامشخص");
            }

            if (amount < coverage.MinAmount )
            {
                
                return 0;
            }
            if ( amount > coverage.MaxAmount)
            {
                amount = coverage.MaxAmount;
                
            }
            return amount * coverage.PremiumRate;
        }

        public async Task<List<InsuranceRequestDto>> GetAllInsuranceRequests()
        {
            var response = await _insuranceRepository.GetAllInsuranceRequests();
            return response.Select(x => new InsuranceRequestDto
            {
                RequestCoverage = x.RequestCoverages.Select(c => new InsuranceRequestCoverageDto
                {
                    Type = c.Coverage.Type,
                     CoverageId=c.CoverageId,
                     PaymentAmount=c.PayementAmount,
                }).ToList(),
                Amount=x.Amount,
             
                Title = x.Title
            }).ToList();
        }

        private async Task<List<Coverage>> GetCoverage()
        {
            var cachedCoverages = await _memoryCoverageCacheService.GetCoveragesAsync();
            if (cachedCoverages != null)
            {
                return cachedCoverages.ToList();
            }
            var coverages = await _insuranceRepository.GetCoverages();
            await _memoryCoverageCacheService.SetAllCovergeAsync(coverages);
            return coverages;
        }
        private async Task<int> GetCoverageById(int typeCoverage)
        {
            var coverages = await GetCoverage();
            var coverageId = coverages.Where(c => c.Type == typeCoverage).FirstOrDefault().Id;
            return coverageId;
        }

    }
}
