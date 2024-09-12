using MediatR;
using PremiumAccountService.Application.Commands;
using PremiumAccountService.Application.DTO;
using PremiumAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PremiumAccountService.Application.Utility
{
    public static class ExtentionMethod
    {
        public  static InsuranceRequestDto ToInsuranceRequest(this CreateInsuranceRequestCommand request)
        {
            return new InsuranceRequestDto
            {
                Amount = request.Amount,
                Coverages = request.Coverages.Select(x => new CoverageDto
                {
                    InsuranceRequestId = x.InsuranceRequestId,
                    MaxAmount = x.MaxAmount,
                    MinAmount = x.MinAmount,
                    Type = x.Type,
                    PremiumRate = x.PremiumRate 
                }).ToList(),

            };
        }
        public static List<InsuranceRequestDto> ToInsuranceResponse(this List<InsuranceRequest> responses)
        {
           return responses.Select(c => new InsuranceRequestDto
            {
                Id = c.Id,
                Title = c.Title,
                Amount = c.Amount,
               
            }).ToList();
        }
    }
}
