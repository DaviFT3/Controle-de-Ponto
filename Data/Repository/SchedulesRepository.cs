using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(SqlContext context) : base(context)
        {
        }
        public IEnumerable<Schedule> GetAll()
        {
            var obj = CurrentSet
                       .Include(x => x.Collaborator).ToList();

            return obj;
        }
        public IEnumerable<Schedule> GetAllScheduleByCollaboratorId(int id)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .Where(x => x.Collaborator.Id == id).ToList();

            return obj;
        }
        public IEnumerable<Schedule> GetAllScheduleByCollaboratorIdByMonthAndYear(int id, int year, int month)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .Where(x => x.Collaborator.Id == id && (x.EntryTime.Month == month && x.EntryTime.Year == year)).ToList();

            return obj;
        }
        public Schedule CheckSchedules(int id)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .Where(x => x.CollaboratorId == id && (x.EntryTime.Date >= DateTime.Today))
                .FirstOrDefault();

            return obj;
        }

        public double TotalHoursWorked(int id)
        {
            var total = new Schedule();
            total.CollaboratorId = id;
            TimeSpan result;

            result = (total.DepartureTime - total.EntryTime) - (total.LunchReturnTime - total.LunchTime);
            return result.Hours;

        }

    }
}
