using Microsoft.EntityFrameworkCore;
using PremiumAccountService.Domain.Entities;

namespace PremiumAccountService.Infrastructure.Context
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {

        }
        public DbSet<Coverage> coverages { get; set; }
        public DbSet<InsuranceRequest> InsuranceRequests { get; set; }
        public DbSet<InsuranceRequestCoverage> InsuranceRequestCoverages { get; set; }
    }

}
