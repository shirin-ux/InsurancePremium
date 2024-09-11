using PremiumAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Infrastructure.IInsuranceRepository
{
    public interface IInsuranceRepository
    {
        Task<List<Coverage>> GetCoveragesByIds(List<int> coverageIds);
    }
}
