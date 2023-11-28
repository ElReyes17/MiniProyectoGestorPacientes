

using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using GestorPacientes.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{

    public class RepositorioCitas : RepositorioGenerico<Citas>, IRepositorioCitas
    {
        private readonly ApplicationContext _context;
        public RepositorioCitas(ApplicationContext context) : base(context) {
        
        _context = context;
        
        }

      
    }
}
