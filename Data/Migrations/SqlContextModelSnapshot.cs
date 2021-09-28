﻿// <auto-generated />
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Collaborator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Active");

                    b.Property<string>("Assignment")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Assignment");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CPF");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("HiringType")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Hiring Type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Senha");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasColumnName("Phone");

                    b.Property<bool>("Vacations")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Vacations");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Corporate Name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Project")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Project");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollaboratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Departure Time");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Entry Time");

                    b.Property<DateTime>("LunchReturnTime")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Lunch Return Time");

                    b.Property<DateTime>("LunchTime")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Lunch Time");

                    b.Property<string>("WorkedHours")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Worked Hours");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("Domain.Entities.Collaborator", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.Schedule", b =>
                {
                    b.HasOne("Domain.Entities.Collaborator", "Collaborator")
                        .WithMany()
                        .HasForeignKey("CollaboratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collaborator");
                });
#pragma warning restore 612, 618
        }
    }
}
