

using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using GestorPacientes.Infrastructure.Persistence.Repositories.Generics;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
   public class RepositorioPacientes : RepositorioGenerico<Pacientes>, IRepositorioPacientes
    {
        public RepositorioPacientes(ApplicationContext context) : base(context) { }
       
    }
}
