using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Configure
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConexaoDB")));
        }
    }
}
