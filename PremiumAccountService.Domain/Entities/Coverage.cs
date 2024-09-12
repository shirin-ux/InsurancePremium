﻿using System.ComponentModel;

namespace PremiumAccountService.Domain.Entities
{
    public class Coverage
    {
        public int Id { get; set; }
        public short Type { get; set; }
        public decimal PremiumRate { get; set; }
        public int InsuranceRequestId { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public virtual InsuranceRequest InsuranceRequest { get; set; }
    }
   
}
