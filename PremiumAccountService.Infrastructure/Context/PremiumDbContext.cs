using Microsoft.EntityFrameworkCore;
using PremiumAccountService.Domain.Entities;

namespace PremiumAccountService.Infrastructure.Context
{
    public class PremiumDbContext : DbContext
    {
        public PremiumDbContext(DbContextOptions<PremiumDbContext> options) : base(options)
        {

        }
        public DbSet<Coverage> coverages { get; set; }
    }

}
