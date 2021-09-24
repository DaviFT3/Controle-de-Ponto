using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class ScheduleValidator : AbstractValidator<Schedule>
    {
        public ScheduleValidator()
        {
            RuleFor(c => c.EntryTime)
               .NotEmpty().WithMessage("Please enter the Entry Time.")
               .NotNull().WithMessage("Please enter the Entry Time.");

            RuleFor(c => c.LunchTime)
                    .NotEmpty().WithMessage("Please enter the Lunch Time.")
                    .NotNull().WithMessage("Please enter the Lunch Time.");

            RuleFor(c => c.LunchReturnTime)
                    .NotEmpty().WithMessage("Please enter the Lunch Return Time.")
                    .NotNull().WithMessage("Please enter the Lunch Return Time.");

            RuleFor(c => c.DepartureTime)
                    .NotEmpty().WithMessage("Please enter the Departure Time.")
                    .NotNull().WithMessage("Please enter the Departure Time.");

        }
    }
}
