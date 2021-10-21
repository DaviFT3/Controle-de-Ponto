using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }

        public DbSet<DayOff> DayOffs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Collaborator>(new CollaboratorMap().Configure);
            modelBuilder.Entity<Company>(new CompanyMap().Configure);
            modelBuilder.Entity<Schedule>(new ScheduleMap().Configure);
            modelBuilder.Entity<Dashboard>(new DashboardMap().Configure);
            modelBuilder.Entity<DayOff>(new DayOffMap().Configure);



        }
    }
}
