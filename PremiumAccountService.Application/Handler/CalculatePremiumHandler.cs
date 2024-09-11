using MediatR;
using PremiumAccountService.Application.Commands;
using PremiumAccountService.Infrastructure.IInsuranceRepository;

namespace PremiumAccountService.Application.Handler
{
    public class CalculatePremiumHandler : IRequestHandler<CalculatePremiumCommand, decimal>
    {
        private readonly IInsuranceRepository _insuranceRepository;
        public CalculatePremiumHandler(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository; 
        }
        public async Task<decimal> Handle(CalculatePremiumCommand request, CancellationToken cancellationToken)
        {
            var coverages = await _insuranceRepository.GetCoveragesByIds(request.CoverageIds);
            var premium = coverages.Sum(c => c.Rate * request.Amount);
            return premium;

        }
    }
}
