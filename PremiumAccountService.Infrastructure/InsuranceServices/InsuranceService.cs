using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PremiumAccountService.Application.DTO;
using PremiumAccountService.Application.IInsuranceServices;
using PremiumAccountService.Application.IRepository;
using PremiumAccountService.Domain.Entities;
using PremiumAccountService.Domain.IInMemoryCacheService;
using PremiumAccountService.Infrastructure.InMemoryCacheService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Infrastructure.InsuranceServices
{
    public class InsuranceService(IInsuranceRepository insuranceRepository, IInMemoryCoverageCacheService memoryCoverageCacheService) : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository = insuranceRepository;
        private readonly IInMemoryCoverageCacheService _memoryCoverageCacheService = memoryCoverageCacheService;

        public async Task<decimal> AddInsuranceRequest(InsuranceRequestDto request)
        {
            decimal totalPremium = 0;
            foreach (var coverageRequest in request.Coverages)
            {
                totalPremium += await CalculatePremiumAsync(coverageRequest.Type, coverageRequest.PremiumRate);
            }

            var insuranceRequest = new InsuranceRequest
            {
                Title = request.Title,
                Coverages = request.Coverages.Select(c => new Coverage
                {
                    Type = c.Type,
                    MinAmount = c.MinAmount,
                    MaxAmount = c.MaxAmount,
                    PremiumRate = c.PremiumRate
                }).ToList(),
                Amount = request.Coverages.Sum(c => c.PremiumRate),
                TotalPremium = totalPremium
            };
            await _insuranceRepository.AddInsuranceRequest(insuranceRequest);
            return totalPremium;
        }

        public async Task<decimal> CalculatePremiumAsync(short typeCoverage, decimal amount)
        {
            var coverages = await GetCoverage();
            var coverage = coverages.Where(c => c.Type == typeCoverage).FirstOrDefault();

            if (coverage == null)
            {
                throw new ArgumentException("پوشش نامشخص");
            }

            if (amount < coverage.MinAmount || amount > coverage.MaxAmount)
            {
                throw new ArgumentException("مقدار وارد شده در محدوده مجاز نیست");
            }
            return amount * coverage.PremiumRate;
        }

        public async Task<List<InsuranceRequestDto>> GetAllInsuranceRequests()
        {
            var response = await _insuranceRepository.GetAllInsuranceRequests();
            return response.Select(x=>new InsuranceRequestDto
            {
                Amount=x.Amount,
                Premium=x.TotalPremium,
                Title=x.Title
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

    }
}
