using MediatR;
using PremiumAccountService.Application.Commands;
using PremiumAccountService.Application.IInsuranceServices;
using PremiumAccountService.Application.Utility;


namespace PremiumAccountService.Application.Handler
{
    public class CreateInsuranceRequestHandler(IInsuranceService insuranceService) :
        IRequestHandler<CreateInsuranceRequestCommand, decimal>
    {
        private readonly IInsuranceService _insuranceService;
        public async Task<decimal> Handle(CreateInsuranceRequestCommand request, CancellationToken cancellationToken)
        {
            return await _insuranceService.AddInsuranceRequest(request.ToInsuranceRequest());
        }
    }

}


