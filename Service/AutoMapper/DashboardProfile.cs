using AutoMapper;
using Domain.Entities;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
            => CreateMap<Dashboard, DashboardViewModel>().ReverseMap()
            .ForMember(dto => dto.Collaborator, opt => opt.MapFrom(x => x.Collaborator));

    }
}
