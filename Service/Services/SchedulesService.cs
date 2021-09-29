﻿using AutoMapper;
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
        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper, IBaseRepository<Schedule> baseRepository)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
            _baseRepository = baseRepository;
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
                objcheck.WorkedHours = TotalHoursWorked(objcheck).ToString();
                _baseRepository.Update(objcheck);
                return _mapper.Map<ScheduleViewModel>(objcheck);
            }
        }
        public double TotalHoursWorked(Schedule obj)
        {
            TimeSpan result;

            result = (obj.DepartureTime - obj.EntryTime) - (obj.LunchReturnTime - obj.LunchTime);
            return result.Hours;

        }
    }
}