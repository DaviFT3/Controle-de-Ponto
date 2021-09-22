using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class CollaboratorViewModel
    {
        public string CPF { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public bool Vacations { get; set; }

        public bool Active { get; set; }

        public string Assignment { get; set; }

        public string HiringType { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
