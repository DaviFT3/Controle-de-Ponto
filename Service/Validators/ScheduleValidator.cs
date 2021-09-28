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
            RuleFor(c => c.EntryTime);


            RuleFor(c => c.LunchTime);


            RuleFor(c => c.LunchReturnTime);


            RuleFor(c => c.DepartureTime);
                   

        }
    }
}
