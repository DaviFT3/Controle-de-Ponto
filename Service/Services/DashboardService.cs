using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Dashboard> _baseRepository;
        private readonly IScheduleService _scheduleService;

        public DashboardService(IDashboardRepository scheduleRepository, IMapper mapper, IBaseRepository<Dashboard> baseRepository, IScheduleService scheduleService)
        {
            _dashboardRepository = scheduleRepository;
            _mapper = mapper;
            _baseRepository = baseRepository;
            _scheduleService = scheduleService;
        }
        public IEnumerable<DashboardViewModel> GetAll()
        {
            var obj = _dashboardRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<DashboardViewModel>>(obj);
            return objviewmodel;

        }
       public DashboardViewModel UpdateDashboard(int idUser)
        {
            var obj = _dashboardRepository.GetCollaborator(idUser);
            var objviewmodel = _mapper.Map<DashboardViewModel>(obj);
            var recentDates = _scheduleService.GetLastRegisters(idUser);
            objviewmodel.RecentDates = recentDates;
            return objviewmodel;
        }

    }
}
