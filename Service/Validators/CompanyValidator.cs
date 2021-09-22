using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("Please enter the name.")
               .NotNull().WithMessage("Please enter the name.");

            RuleFor(c => c.CNPJ)
                    .NotEmpty().WithMessage("Please enter the CNPJ.")
                    .NotNull().WithMessage("Please enter the CNPJ.");

            RuleFor(c => c.CorporateName)
                    .NotEmpty().WithMessage("Please enter the Corporate Name.")
                    .NotNull().WithMessage("Please enter the Corporate Name.");

            RuleFor(c => c.Project)
                    .NotEmpty().WithMessage("Please enter the Project.")
                    .NotNull().WithMessage("Please enter the Project.");

        }
    }
}
