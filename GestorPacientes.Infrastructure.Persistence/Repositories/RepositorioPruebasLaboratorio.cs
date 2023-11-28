

using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using GestorPacientes.Infrastructure.Persistence.Repositories.Generics;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class RepositorioPruebasLaboratorio : RepositorioGenerico<PruebasLaboratorio>, IRepositorioPruebasLaboratorio

    {
        public RepositorioPruebasLaboratorio(ApplicationContext context) : base(context) { }
        
        
    }
}
