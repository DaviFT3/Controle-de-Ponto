using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class ScheduleViewModel
    {
        public DateTime EntryTime { get; set; }

        public DateTime LunchTime { get; set; }

        public DateTime LunchReturnTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public double WorkedHours { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }
    }
}
