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
    public class DayOffRepository : BaseRepository<DayOff>, IDayOffRepository
    {
        public DayOffRepository(SqlContext context) : base(context)
        {

        }
        public IEnumerable<DayOff> GetAllDayoffsByCollaboratorId()
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .Include(x => x.Company);

            return obj;
        }

        

        public DayOff GetDayOffByYearAndMonthAndUserId(int idUser, int year, int month)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .ThenInclude(x => x.Company)
                .Where(x => x.Collaborator.Id == idUser && (x.DayOffDate.Month == month && x.DayOffDate.Year == year))
                .FirstOrDefault();
            return obj;
        }
    }
}
