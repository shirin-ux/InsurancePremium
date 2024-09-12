using PremiumAccountService.Application.DTO;
using PremiumAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.IInsuranceServices
{
    public interface IInsuranceService
    {
        Task<decimal> CalculatePremiumAsync(short typeCoverage, decimal amount);
        Task<decimal> AddInsuranceRequest(InsuranceRequestDto request);
        Task<List<InsuranceRequestDto>> GetAllInsuranceRequests();
    }
}
