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
    public class HappyFridayService : IDayOffService
    {
        private readonly IDayOffRepository _dayOffRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<DayOff> _baseRepository;
        private readonly ICollaboratorRepository _collaboratorRepository;

        public HappyFridayService(IDayOffRepository dayOffRepository,
            IMapper mapper,
            IBaseRepository<DayOff> baseRepository,
            ICollaboratorRepository collaboratorRepository)

        {
            _dayOffRepository = dayOffRepository;
            _mapper = mapper;
            _baseRepository = baseRepository;
            _collaboratorRepository = collaboratorRepository;
        }

        public IEnumerable<DayOffViewModel> GetDayOffByCompanyId(int companyId, int year, int month)
        {
            var collaborators = _mapper.Map<IEnumerable<CollaboratorViewModel>>(_collaboratorRepository.GetByCompanyId(companyId));

            var happyFridaday = new List<DayOffViewModel>();

            foreach (var alt in collaborators)
            {
                var happy = new DayOffViewModel();
                happy.CollaboratorId = alt.Id;
                happy.Collaborator = alt;
                happy.CompanyId = alt.CompanyId;
                happy.DayOffDate = DateHappyFriday(alt.Id, year, month);
                happyFridaday.Add(happy);
            }
            return happyFridaday;
        }
        public DayOffViewModel Create(DayOffViewModel obj)
        {
            var collaboratorHappy = _dayOffRepository.GetDayOffByYearAndMonthAndUserId(obj.CollaboratorId, obj.DayOffDate.Year, obj.DayOffDate.Month);
            if (collaboratorHappy != null)
            {
                return new DayOffViewModel();
            }
            else
            {
                var collaboratordayoff = _mapper.Map<DayOff>(obj);
                _baseRepository.Insert(collaboratordayoff);
                return obj;
            }
        }
        public IEnumerable<DayOffViewModel> GetAllByCollaboratorId()
        {
            var obj = _dayOffRepository.GetAllDayoffsByCollaboratorId();
            var objviewmodel = _mapper.Map<IEnumerable<DayOffViewModel>>(obj);
            return objviewmodel;
        }
        public DateTime DateHappyFriday(int idUser, int year, int month)
        {
            var collaboratorHappy = _dayOffRepository.GetDayOffByYearAndMonthAndUserId(idUser, year, month);
            if (collaboratorHappy != null)
            {
                return collaboratorHappy.DayOffDate;
            }
            else
            {
                return new DateTime();
            }
        }
    }
}
