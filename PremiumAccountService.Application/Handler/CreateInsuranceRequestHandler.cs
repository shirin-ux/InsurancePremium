using MediatR;
using PremiumAccountService.Application.Commands;
using PremiumAccountService.Application.IInsuranceServices;
using PremiumAccountService.Application.Utility;


namespace PremiumAccountService.Application.Handler
{
    public class CreateInsuranceRequestHandler :
        IRequestHandler<CreateInsuranceRequestCommand, decimal>
    {

        private readonly IInsuranceService _insuranceService;
        public CreateInsuranceRequestHandler(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }
        public async Task<decimal> Handle(CreateInsuranceRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _insuranceService.AddInsuranceRequest(new DTO.InsuranceRequestDto
                {
                   Coverage=request.Coverages,
                    Title = request.Title,
                    Amount=request.Amount,
                   
                });
            }
            catch (Exception ex)
            {

                throw;
            }
   
        }
    }

}


