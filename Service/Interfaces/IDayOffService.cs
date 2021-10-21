using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDayOffService
    {
        IEnumerable<DayOffViewModel> GetDayOffByCompanyId(int companyId, int year, int month);

        IEnumerable<DayOffViewModel> GetAllByCollaboratorId();
        DayOffViewModel Create(DayOffViewModel obj);

    }
}
