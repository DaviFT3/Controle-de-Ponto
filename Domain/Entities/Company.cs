using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string CorporateName { get; set; }

        public string Project { get; set; }


    }
}
