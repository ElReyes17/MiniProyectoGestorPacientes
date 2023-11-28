using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace GestorPacientes.Core.Application
{
    public static class ServicesRegistration
    {
        public static void AddCoreApplication(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IServiciosUsuarios, ServiciosUsuarios>();
            services.AddScoped<IServiciosMedicos, ServiciosMedicos>();
            services.AddScoped<IServiciosPacientes, ServiciosPacientes>();
            services.AddScoped<IServiciosCitas, ServiciosCitas>();
            services.AddScoped<IServiciosPruebasLaboratorio, ServiciosPruebasLaboratorio>();
            services.AddScoped<IServiciosResultadosLaboratorio, ServiciosResultadosLaboratorio>();      
            #endregion

        }
    }
}
