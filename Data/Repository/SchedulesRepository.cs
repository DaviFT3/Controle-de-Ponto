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
    }
}
