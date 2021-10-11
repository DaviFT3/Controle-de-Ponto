using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDashboardService
    {
        IEnumerable<DashboardViewModel> GetAll();

        DashboardViewModel UpdateDashboard(int idUser);
    }
}
