using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class CollaboratorValidator : AbstractValidator<Collaborator>
    {
        public CollaboratorValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty().WithMessage("Please enter the name.")
               .NotNull().WithMessage("Please enter the name.");

            RuleFor(c => c.Email)
                    .NotEmpty().WithMessage("Please enter the email.")
                    .NotNull().WithMessage("Please enter the email.");

            RuleFor(c => c.Password)
                    .NotEmpty().WithMessage("Please enter the password.")
                    .NotNull().WithMessage("Please enter the password.")
                    .MinimumLength(8).WithMessage("O tamanho minimo é de 08 caracteres")
                    .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter pelo menos uma letra maiúscula.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Sua senha deve conter pelo menos uma letra minúscula.")
                    .Matches(@"[\!\?\*\.\@\#\-\!]+").WithMessage("Sua senha deve conter pelo menos um (!? *.).");

            RuleFor(c => c.CPF)
               .NotEmpty().WithMessage("Please enter the CPF.")
               .NotNull().WithMessage("Please enter the CPF.")
               .MinimumLength(14).WithMessage("O tamanho minimo é de 11 caracteres");

            RuleFor(c => c.Phone)
               .NotEmpty().WithMessage("Please enter the Phone.")
               .NotNull().WithMessage("Please enter the Phone.");

            RuleFor(c => c.Assignment)
               .NotEmpty().WithMessage("Please enter the Assignment.")
               .NotNull().WithMessage("Please enter the Assignment.");

            RuleFor(c => c.HiringType)
               .NotEmpty().WithMessage("Please enter the Hiring Type.")
               .NotNull().WithMessage("Please enter the Hiring Type.");


        }
    }
}
