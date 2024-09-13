using PremiumAccountService.Application.DTO;
using PremiumAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.IRepository
{
    public interface IInsuranceRepository
    {
        Task AddInsuranceRequest(InsuranceRequest insuranceRequest);
        Task<List<Coverage>> GetCoverages();
        Task<List<InsuranceRequest>> GetAllInsuranceRequests();
       
    }
}
