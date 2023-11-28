using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Repositories.Generics;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using GestorPacientes.Infrastructure.Persistence.Repositories;
using GestorPacientes.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorPacientes.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
           

            #endregion

            #region Repositories

            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
          
            services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            services.AddScoped<IRepositorioCitas, RepositorioCitas>();
            services.AddScoped<IRepositorioPacientes, RepositorioPacientes>();
            services.AddScoped<IRepositorioPruebasLaboratorio, RepositorioPruebasLaboratorio>();
            services.AddScoped<IRepositorioResultadosLaboratorio, RepositorioResultadosLaboratorio>();
            services.AddScoped<IRepositorioMedicos, RepositorioMedicos>();
            services.AddScoped<IRepositorioEstadoCita, RepositorioEstadoCita>();
            services.AddScoped<IRepositorioEstadoResultado, RepositorioEstadoResultado>();

            #endregion
        }

    }
}
