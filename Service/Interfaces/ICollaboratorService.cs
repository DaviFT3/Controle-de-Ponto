using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICollaboratorService
    {
        CollaboratorViewModel GetAllAuthentication(string email, string password);
    }
}
