using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class DashboardMap : IEntityTypeConfiguration<Dashboard>
    {
        public void Configure(EntityTypeBuilder<Dashboard> builder)
        {
            builder.ToTable("Dashboard");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Balance)
            .HasConversion(prop => prop, prop => prop)
            .HasColumnName("Hours Balance")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Workload)
            .HasConversion(prop => prop, prop => prop)
            .HasColumnName("Workload")
            .HasColumnType("varchar(100)");



        }
    }
}