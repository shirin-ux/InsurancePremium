using MediatR;
using PremiumAccountService.Application.DTO;
using PremiumAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.Commands
{
    public class CreateInsuranceRequestCommand:IRequest<decimal>
    {
        public string Title { get; set; }
        public List<CoverageDto> Coverages { get; set; }
        public decimal Amount { get; set; }
    }

}
