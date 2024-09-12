using MediatR;
using PremiumAccountService.Application.DTO;
using PremiumAccountService.Domain.Entities;

namespace PremiumAccountService.Application.Query
{
    public class GetInsuranceRequestsQuery : IRequest<List<InsuranceRequestDto>>
    {
    }
}
