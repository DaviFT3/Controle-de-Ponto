using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICollaboratorRepository
    {
        Collaborator GetAllAuthentication(string emailAut, string PasswordAut);

        IEnumerable<Collaborator> GetAll();

        IEnumerable<Collaborator> GetByCompanyId(int idCompany);

        Collaborator GetById(int id);
    }
}
