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
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
            => CreateMap<Company, CompanyViewModel>().ReverseMap();
    }
}
