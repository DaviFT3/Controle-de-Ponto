using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> GetAll();

        IEnumerable<Schedule> GetAllScheduleByCollaboratorId(int id);

        Schedule CheckSchedules(int id);

        double TotalHoursWorked(int id);
    }
}
