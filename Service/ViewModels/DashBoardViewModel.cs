using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class DashboardViewModel
    {
        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }

        public double Balance { get; set; }

        public double Workload { get; set; }

        public IEnumerable<ScheduleViewModel> RecentDates { get; set; }

       

    }
}
