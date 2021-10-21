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
    public class CollaboratorRepository : BaseRepository<Collaborator>, ICollaboratorRepository
    {
        public CollaboratorRepository(SqlContext context) : base(context)
        {
        }
        public Collaborator GetAllAuthentication(string emailAut, string passwordAut)
        {
            var obj = CurrentSet
                       .Where(x => x.Email == emailAut && x.Password == passwordAut)
                       .First();
            return obj;
        }

        public Collaborator GetById(int id)
        {
            var obj = CurrentSet
                      .Include(x => x.Company).Where(x => x.Id == id).FirstOrDefault();

            return obj;
        }
        public IEnumerable<Collaborator> GetByCompanyId(int idCompany)
        {
            var obj = CurrentSet
                          .Include(x => x.Company)
                          .Where(x => x.CompanyId == idCompany).ToList();

            return obj;
        }

        public IEnumerable<Collaborator> GetAll()
        {
            var obj = CurrentSet
                       .Include(x => x.Company).ToList();

            return obj;
        }
    }
}
