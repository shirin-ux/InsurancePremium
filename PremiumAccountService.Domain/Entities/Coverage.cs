using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremiumAccountService.Domain.Entities
{
    public class Coverage
    {
        public int Id { get; set; }
        public int Type { get; set; }
        [Column(TypeName= "decimal(18,4)")]
        public decimal PremiumRate { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal MinAmount { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal MaxAmount { get; set; }
    }
   
}
