using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.DTO
{
    public class InsuranceRequestCoverageDto
    {
        public int CoverageId {  get; set; }   
        public int Type { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
