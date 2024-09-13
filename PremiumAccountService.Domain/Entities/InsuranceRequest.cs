using System.ComponentModel.DataAnnotations.Schema;

namespace PremiumAccountService.Domain.Entities
{
    public class InsuranceRequest
    {
        public InsuranceRequest()
        {
            RequestCoverages = new List<InsuranceRequestCoverage>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<InsuranceRequestCoverage> RequestCoverages { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal Amount { get; set; }

        
    }
}
