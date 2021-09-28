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
    public class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable("User");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Email)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Password)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Senha")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.CPF)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("CPF")
            .HasColumnType("varchar(14)");

            builder.Property(prop => prop.Phone)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Phone")
            .HasColumnType("varchar(16)");

            builder.Property(prop => prop.Phone)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Phone")
            .HasColumnType("varchar(16)");

            builder.Property(prop => prop.Vacations)
            .HasConversion(prop => prop, prop => prop)
            .IsRequired()
            .HasColumnName("Vacations")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Active)
            .HasConversion(prop => prop, prop => prop)
            .IsRequired()
            .HasColumnName("Active")
            .HasColumnType("varchar(100)");

            
            builder.Property(prop => prop.Assignment)
           .HasConversion(prop => prop.ToString(), prop => prop)
           .IsRequired()
           .HasColumnName("Assignment")
           .HasColumnType("varchar(100)");

            builder.Property(prop => prop.HiringType)
           .HasConversion(prop => prop.ToString(), prop => prop)
           .IsRequired()
           .HasColumnName("Hiring Type")
           .HasColumnType("varchar(100)");

            
        }
    }
}
