namespace PremiumAccountService.Domain.Entities
{
    public class InsuranceRequest
    {
        public InsuranceRequest()
        {
            Coverages = new List<Coverage>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Coverage> Coverages { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalPremium { get; set; }
        
    }
}
