using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.DTO
{
    public class CoverageDto
    {
        public short Type { get; set; }
        public decimal PremiumRate { get; set; }
        public int InsuranceRequestId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
    }
   
}
