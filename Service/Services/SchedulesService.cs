using AutoMapper;
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
        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public IEnumerable<ScheduleViewModel> GetAll()
        {
            var obj = _scheduleRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<ScheduleViewModel>>(obj);
            return objviewmodel;

        }
    }
}
