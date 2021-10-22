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
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Schedule> _baseRepository;
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IBaseRepository<Dashboard> _baseDashboardRepository;
        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper, IBaseRepository<Schedule> baseRepository, IDashboardRepository dashboardRepository,
             IBaseRepository<Dashboard> baseDashboardRepository)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
            _baseRepository = baseRepository;
            _dashboardRepository = dashboardRepository;
            _baseDashboardRepository = baseDashboardRepository;
        }

        public IEnumerable<ScheduleViewModel> GetAll()
        {
            var obj = _scheduleRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<ScheduleViewModel>>(obj);
            return objviewmodel;

        }
        public IEnumerable<ScheduleViewModel> GetAllByCollaboratorId(int id)
        {
            var obj = _scheduleRepository.GetAllScheduleByCollaboratorId(id);
            var objviewmodel = _mapper.Map<IEnumerable<ScheduleViewModel>>(obj);
            return objviewmodel;
        }
        public IEnumerable<ScheduleViewModel> GetLastRegisters(int idUser)
        {
            var pastdate = DateTime.Now.AddDays(-7);
            var todaydate = DateTime.Now;
            var obj = _scheduleRepository.GetAllScheduleByCollaboratorId(idUser);
            var dashboarddates = obj.Where(Schedule => Schedule.EntryTime.Date <= todaydate && Schedule.EntryTime.Date > pastdate).ToList();
            var objviewmodel = _mapper.Map<IEnumerable<ScheduleViewModel>>(dashboarddates);
            return objviewmodel;
        }
       
        public ScheduleViewModel BeatTime(int idUser)
        {
            var objcheck = _scheduleRepository.CheckSchedules(idUser);
            if (objcheck == null)
            {

                var objViewModel = new ScheduleViewModel() { CollaboratorId = idUser, EntryTime = DateTime.Now };
                var obj = _mapper.Map<Schedule>(objViewModel);
                _baseRepository.Insert(obj);

                return objViewModel;

            }
            else if (objcheck.LunchTime.Date != DateTime.Today)
            {
                objcheck.LunchTime = DateTime.Now;
                _baseRepository.Update(objcheck);
                return _mapper.Map<ScheduleViewModel>(objcheck);
            }
            else if (objcheck.LunchReturnTime.Date != DateTime.Today)
            {
                objcheck.LunchReturnTime = DateTime.Now;
                _baseRepository.Update(objcheck);
                return _mapper.Map<ScheduleViewModel>(objcheck);
            }
            else
            {
                objcheck.DepartureTime = DateTime.Now;
                var hoursworked = TotalHoursWorked(objcheck);
                objcheck.WorkedHours = hoursworked;
                _baseRepository.Update(objcheck);
                if (hoursworked > 8)
                {
                    var objdashboard = _dashboardRepository.GetCollaborator(idUser);
                    objdashboard.Balance = objdashboard.Balance +(hoursworked - objdashboard.Workload);
                    _baseDashboardRepository.Update(objdashboard);
                }
                else if (hoursworked < 8)
                {
                    var objdashboard = _dashboardRepository.GetCollaborator(idUser);
                    objdashboard.Balance = objdashboard.Balance - (objdashboard.Workload - hoursworked);
                    _baseDashboardRepository.Update(objdashboard);
                }
                return _mapper.Map<ScheduleViewModel>(objcheck);
            }
        }
        public double HoursBalance(int idUser)
        {
            var obj = _scheduleRepository.GetAllScheduleByCollaboratorId(idUser);
            var workedhours = obj.Where(Schedule => Schedule.WorkedHours != null).ToList();
            double balance = 0;
            foreach (var hours in workedhours)
            {
                if (hours.WorkedHours > 8)
                {
                    balance = balance + (hours.WorkedHours - 8);
                }
                else if (hours.WorkedHours < 8)
                {
                    balance = balance - (8 - hours.WorkedHours);
                }
            }
            return balance;
        }
        public double TotalHoursWorked(Schedule obj)
        {
            TimeSpan result;

            result = (obj.DepartureTime - obj.EntryTime) - (obj.LunchReturnTime - obj.LunchTime);
            return result.Hours;

        }
        public IEnumerable<ScheduleViewModel> GetAllByCollaboratorIdAndYearAndMonth(int id, int year, int month)
        {
            var obj = _scheduleRepository.GetAllScheduleByCollaboratorIdByMonthAndYear(id, year, month);
            var objviewmodel = _mapper.Map<IEnumerable<ScheduleViewModel>>(obj);
            return objviewmodel;
        }
        public ScheduleViewModel GetSchedulesByUserByToday(int idUser)
        {
            var objcheck = _scheduleRepository.CheckSchedules(idUser);
            if (objcheck == null)
            {

                var objViewModel = new ScheduleViewModel() { CollaboratorId = idUser, EntryTime = DateTime.Parse("0001-01-01T00:00:00") };
                return objViewModel;

            }
            else
            {
                return _mapper.Map<ScheduleViewModel>(objcheck);
            }

        }
    }
}
