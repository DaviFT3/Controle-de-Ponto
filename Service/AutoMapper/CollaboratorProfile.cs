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
    public class CollaboratorProfile : Profile
    {
        public CollaboratorProfile()
            => CreateMap<Collaborator, CollaboratorViewModel>().ReverseMap()
            .ForMember(dto => dto.Company, opt => opt.MapFrom(x => x.Company));
    }
}
