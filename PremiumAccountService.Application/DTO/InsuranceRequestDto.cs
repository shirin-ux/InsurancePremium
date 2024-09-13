using PremiumAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.DTO
{
    public class InsuranceRequestDto
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public List<InsuranceRequestCoverageDto> RequestCoverage { get; set; } = new List<InsuranceRequestCoverageDto>();
        public List<CoverageDto> Coverage { get; set; } = new List<CoverageDto>();
    }
}
