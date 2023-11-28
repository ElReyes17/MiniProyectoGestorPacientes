
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using GestorPacientes.Infrastructure.Persistence.Repositories.Generics;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
   public class RepositorioResultadosLaboratorio : RepositorioGenerico<ResultadosLaboratorio>, IRepositorioResultadosLaboratorio
    {
        public RepositorioResultadosLaboratorio(ApplicationContext context) : base(context) { }
        

         public async Task AddAll(List<ResultadosLaboratorio> T)
        {
            foreach(var item in T)
            {
                await Add(item);
            }
        }
    }
}
