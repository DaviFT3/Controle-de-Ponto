using Domain.Entities;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleViewModel> GetAll();

        IEnumerable<ScheduleViewModel> GetAllByCollaboratorId(int id);

        ScheduleViewModel BeatTime(int idUser);

        ScheduleViewModel GetSchedulesByUserByToday(int idUser);

        IEnumerable<ScheduleViewModel> GetLastRegisters(int idUser);

        double HoursBalance(int idUser);
    }
}
