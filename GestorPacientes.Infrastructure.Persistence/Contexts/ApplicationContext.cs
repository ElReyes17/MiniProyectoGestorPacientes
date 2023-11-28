using GestorPacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorPacientes.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Citas> Citas {get; set;}

        public DbSet<Medicos> Doctors { get; set; }

        public DbSet<Usuarios> Users { get; set; }

        public DbSet<Pacientes> Pacientes { get; set; }

        public DbSet<PruebasLaboratorio> LabTest { get; set; }

        public DbSet<EstadoCita>   AppoimentState { get; set; }

        public DbSet<EstadoResultado> ResultState { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent API 

            //Creacion de Tablas 
            #region table

            modelBuilder.Entity<Citas>().ToTable("Appoiments");

            modelBuilder.Entity<Medicos>().ToTable("Doctors");

            modelBuilder.Entity<Usuarios>().ToTable("Users");

            modelBuilder.Entity<Pacientes>().ToTable("Pacients");

            modelBuilder.Entity<PruebasLaboratorio>().ToTable("LabTest");

            modelBuilder.Entity<ResultadosLaboratorio>().ToTable("LabResults");

            modelBuilder.Entity<EstadoCita>().ToTable("AppoimentState");

            modelBuilder.Entity<EstadoResultado>().ToTable("ResultState");

            #endregion


            //Asignacion LLave Primaria
            #region keys 


            modelBuilder.Entity<Citas>().HasKey(c => c.Id);

            modelBuilder.Entity<Medicos>().HasKey(c => c.Id);

            modelBuilder.Entity<Usuarios>().HasKey(c => c.Id);

            modelBuilder.Entity<Pacientes>().HasKey(c => c.Id);

            modelBuilder.Entity<PruebasLaboratorio>().HasKey(c => c.Id);

            modelBuilder.Entity<ResultadosLaboratorio>().HasKey(c => c.Id);

            modelBuilder.Entity<EstadoCita>().HasKey(c => c.Id);

            modelBuilder.Entity<EstadoResultado>().HasKey(c => c.Id);


            #endregion


            //Relaciones de las tablas 
            #region relationships
           
            modelBuilder.Entity<Citas>()
                .HasOne(medicos => medicos.Doctor)
                .WithMany(medicos => medicos.Citas)
                .HasForeignKey(medicos => medicos.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Citas>()
                .HasOne(pacientes => pacientes.Pacient)
                .WithMany(pacientes => pacientes.Citas)
                .HasForeignKey(pacientes => pacientes.IdPacient)
                .OnDelete(DeleteBehavior.Cascade); 
            
            modelBuilder.Entity<Citas>()
                .HasOne(estado => estado.AppointmentState)
                .WithMany(estado => estado.Citas)
                .HasForeignKey(estado => estado.IdState)
                .OnDelete(DeleteBehavior.Cascade);      

            modelBuilder.Entity<ResultadosLaboratorio>()
                .HasOne(a => a.LabTest)
                .WithMany(a => a.LabResult)
                .HasForeignKey(a => a.IdLabTest)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResultadosLaboratorio>()
                .HasOne(a => a.Pacient)
                .WithMany(a => a.LabResult)
                .HasForeignKey(a => a.IdPacient)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ResultadosLaboratorio>()
                .HasOne(a => a.ResultState)
                .WithMany(a => a.LabResult)
                .HasForeignKey(a => a.IdResultState)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResultadosLaboratorio>()
                .HasOne (a => a.Appoiments)
                .WithMany(a=> a.LabResults)
                .HasForeignKey (a => a.IdAppoiments)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion


            //Configuracion de Campos

            #region Field Configuration



            #endregion



        }


    }
}
