using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DayOff : BaseEntity
    {
        public int CompanyId {get;set;}
        public Company Company { get; set; }

        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }

        public DateTime DayOffDate { get; set; }

        public bool Active { get; set; }
       

    }
}
