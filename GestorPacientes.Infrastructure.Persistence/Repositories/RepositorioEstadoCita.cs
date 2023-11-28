

using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using GestorPacientes.Infrastructure.Persistence.Repositories.Generics;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class RepositorioEstadoCita : RepositorioGenerico<EstadoCita>, IRepositorioEstadoCita
    {
        public RepositorioEstadoCita(ApplicationContext context) : base(context)
        {
            
        }
    }
}
