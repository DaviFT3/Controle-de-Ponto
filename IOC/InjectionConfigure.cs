using Data.Repository;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class Injector
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICollaboratorRepository), typeof(CollaboratorRepository));
            services.AddScoped(typeof(ICollaboratorService), typeof(CollaboratorService));
            services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
            services.AddScoped(typeof(ICompanyService), typeof(CompanyService));
            services.AddScoped(typeof(IScheduleService), typeof(ScheduleService));
            services.AddScoped(typeof(IScheduleRepository), typeof(ScheduleRepository));
            services.AddScoped(typeof(IDashboardService), typeof(DashboardService));
            services.AddScoped(typeof(IDashboardRepository), typeof(DashboardRepository));
            services.AddScoped(typeof(IDayOffRepository), typeof(DayOffRepository));
            services.AddScoped(typeof(IDayOffService), typeof(HappyFridayService));
        }
    }
 }

