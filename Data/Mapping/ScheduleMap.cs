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
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.EntryTime)
            .HasConversion(prop => prop, prop => prop)
            .IsRequired()
            .HasColumnName("Entry Time")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.LunchTime)
            .HasConversion(prop => prop, prop => prop)
            .IsRequired()
            .HasColumnName("Lunch Time")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.LunchReturnTime)
            .HasConversion(prop => prop, prop => prop)
            .IsRequired()
            .HasColumnName("Lunch Return Time")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.DepartureTime)
            .HasConversion(prop => prop, prop => prop)
            .IsRequired()
            .HasColumnName("Departure Time")
            .HasColumnType("varchar(100)");



        }
    }
}
