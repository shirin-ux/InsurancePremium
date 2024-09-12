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
        public int Id { get; set; }
        public string Title { get; set; }
        public List<CoverageDto> Coverages { get; set; }
        public decimal Amount { get; set; }
        public decimal Premium { get; set; }
    }
}
