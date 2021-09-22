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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.CNPJ)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("CNPJ")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.CorporateName)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Corporate Name")
            .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Project)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .IsRequired()
            .HasColumnName("Project")
            .HasColumnType("varchar(100)");



        }
    }
}
