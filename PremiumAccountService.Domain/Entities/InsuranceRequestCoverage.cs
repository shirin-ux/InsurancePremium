using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Domain.Entities
{
    public class InsuranceRequestCoverage
    {
        public int Id { get; set; }
        public int CoverageId { get; set; }
        public virtual Coverage Coverage { get; set; }
        public int InsuranceRequestId { get; set; }
        public virtual InsuranceRequest InsuranceRequest { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal PayementAmount { get; set; }
    }
}
