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

         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coverage>().HasData(
            new Coverage
            {
                Id = 1,
                Type = "جراحی",
                Rate = 0.0052,
                MinAmount = 5000,
                MaxAmount = 50000000
            },
            new Coverage
            {
                Id = 2,
                Type = "دندانپزشکی",
                Rate = 0.0042,
                MinAmount = 4000,
                MaxAmount = 40000000
            },
            new Coverage
            {
                Id = 3,
                CoverageType = "بستری",
                Rate = 0.005,
                MinAmount = 2000,
                MaxAmount = 20000000
            }
        );
    }
}
    }

}
