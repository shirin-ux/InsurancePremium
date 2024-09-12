using MediatR;
using PremiumAccountService.Application.DTO;
using PremiumAccountService.Application.IInsuranceServices;
using PremiumAccountService.Application.IRepository;
using PremiumAccountService.Application.Query;
using PremiumAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.Handler
{
    public class GetInsuranceRequestsHandler(IInsuranceService insuranceService) : 
        IRequestHandler<GetInsuranceRequestsQuery, List<InsuranceRequestDto>>
    {
        private readonly IInsuranceService _insuranceService;
        public async Task<List<InsuranceRequestDto>> Handle(GetInsuranceRequestsQuery request, CancellationToken cancellationToken)
        {
            return await _insuranceService.GetAllInsuranceRequests();
        }

       
    }
}
