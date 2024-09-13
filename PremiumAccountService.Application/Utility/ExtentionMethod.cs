using PremiumAccountService.Application.Commands;
using PremiumAccountService.Application.DTO;
using PremiumAccountService.Domain.Entities;

namespace PremiumAccountService.Application.Utility
{
    public static class ExtentionMethod
    {
        public static InsuranceRequestDto ToInsuranceRequest(this CreateInsuranceRequestCommand request)
        {
            return new InsuranceRequestDto
            {
               
                Coverage = request.Coverages.Select(x => new CoverageDto
                {
                    Type = x.Type,
                }).ToList(),
                Title = request.Title,
                Amount = request.Amount,
            };
        }
        public static List<InsuranceRequestDto> ToInsuranceResponse(this List<InsuranceRequest> responses)
        {
            return responses.Select(c => new InsuranceRequestDto
            {
                Title = c.Title,
                RequestCoverage= c.RequestCoverages.Select(x=>new InsuranceRequestCoverageDto
               {
                   Type=x.Coverage.Type,
                   PaymentAmount=x.PayementAmount
                   
               }).ToList()

            }).ToList();
        }
    }
}
