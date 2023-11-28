
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.ViewModels.Usuarios;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Infrastructure.Persistence.Contexts;
using GestorPacientes.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using GestorPacientes.Core.Application.Helpers;

namespace GestorPacientes.Infrastructure.Persistence.Repositories
{
    public class RepositorioUsuarios : RepositorioGenerico<Usuarios>, IRepositorioUsuarios
    {
        private readonly ApplicationContext _context;
        public RepositorioUsuarios(ApplicationContext context) : base(context) { 
        
             _context = context;
        }

        public override async Task<Usuarios> Add(Usuarios objeto)
        {
            objeto.Password = PasswordEncryptation.ComputeSha256Hash(objeto.Password);
            await base.Add(objeto);

            return objeto;
        }

        public async Task<Usuarios> Login(LoginViewModel objeto)
        {
            string password = PasswordEncryptation.ComputeSha256Hash(objeto.Password);

            Usuarios usuarios = await _context.Set<Usuarios>().FirstOrDefaultAsync(a => a.UserName == objeto.Username && a.Password == password);

            return usuarios;
        }

          public bool ValidacionUsuarios(string nombre)
        {
            return _context.Users.Any(a => a.UserName == nombre);
        }
    }
}
