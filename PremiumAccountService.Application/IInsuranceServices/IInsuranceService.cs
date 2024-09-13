using PremiumAccountService.Application.DTO;

namespace PremiumAccountService.Application.IInsuranceServices
{
    public interface IInsuranceService
    {
        Task<decimal> CalculatePremiumAsync(int typeCoverage, decimal amount);
        Task<decimal> AddInsuranceRequest(InsuranceRequestDto request);
        Task<List<InsuranceRequestDto>> GetAllInsuranceRequests();
    }
}
