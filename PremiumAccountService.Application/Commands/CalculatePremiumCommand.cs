using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.Commands
{
    public class CalculatePremiumCommand:IRequest<decimal>
    {

        public List<int> CoverageIds { get; set; }
        public decimal Amount { get; set; }
    }
}
