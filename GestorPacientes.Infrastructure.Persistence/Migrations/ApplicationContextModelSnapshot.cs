﻿// <auto-generated />
using GestorPacientes.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorPacientes.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Citas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cause")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPacient")
                        .HasColumnType("int");

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPacient");

                    b.HasIndex("IdState");

                    b.ToTable("Appoiments", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.EstadoCita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppointmentState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppoimentState", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.EstadoResultado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ResultState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ResultState", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Medicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Pacientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Alergy")
                        .HasColumnType("bit");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Smoke")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pacients", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.PruebasLaboratorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LabTest", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.ResultadosLaboratorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdAppoiments")
                        .HasColumnType("int");

                    b.Property<int>("IdLabTest")
                        .HasColumnType("int");

                    b.Property<int>("IdPacient")
                        .HasColumnType("int");

                    b.Property<int>("IdResultState")
                        .HasColumnType("int");

                    b.Property<string>("Resultado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAppoiments");

                    b.HasIndex("IdLabTest");

                    b.HasIndex("IdPacient");

                    b.HasIndex("IdResultState");

                    b.ToTable("LabResults", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Citas", b =>
                {
                    b.HasOne("GestorPacientes.Core.Domain.Entities.Medicos", "Doctor")
                        .WithMany("Citas")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorPacientes.Core.Domain.Entities.Pacientes", "Pacient")
                        .WithMany("Citas")
                        .HasForeignKey("IdPacient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorPacientes.Core.Domain.Entities.EstadoCita", "AppointmentState")
                        .WithMany("Citas")
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentState");

                    b.Navigation("Doctor");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.ResultadosLaboratorio", b =>
                {
                    b.HasOne("GestorPacientes.Core.Domain.Entities.Citas", "Appoiments")
                        .WithMany("LabResults")
                        .HasForeignKey("IdAppoiments")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorPacientes.Core.Domain.Entities.PruebasLaboratorio", "LabTest")
                        .WithMany("LabResult")
                        .HasForeignKey("IdLabTest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorPacientes.Core.Domain.Entities.Pacientes", "Pacient")
                        .WithMany("LabResult")
                        .HasForeignKey("IdPacient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GestorPacientes.Core.Domain.Entities.EstadoResultado", "ResultState")
                        .WithMany("LabResult")
                        .HasForeignKey("IdResultState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appoiments");

                    b.Navigation("LabTest");

                    b.Navigation("Pacient");

                    b.Navigation("ResultState");
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Citas", b =>
                {
                    b.Navigation("LabResults");
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.EstadoCita", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.EstadoResultado", b =>
                {
                    b.Navigation("LabResult");
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Medicos", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.Pacientes", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("LabResult");
                });

            modelBuilder.Entity("GestorPacientes.Core.Domain.Entities.PruebasLaboratorio", b =>
                {
                    b.Navigation("LabResult");
                });
#pragma warning restore 612, 618
        }
    }
}
