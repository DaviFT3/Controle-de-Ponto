using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class DashboardValidator : AbstractValidator<Dashboard>
    {
        public DashboardValidator()
        {
            RuleFor(c => c.Balance);
               

            RuleFor(c => c.Workload)
                    .NotEmpty().WithMessage("Please enter the workload.")
                    .NotNull().WithMessage("Please enter the workload."); 


        }
    }
}
