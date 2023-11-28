
using GestorPacientes.Core.Application.Interfaces.Repositories.Generics;
using GestorPacientes.Core.Application.ViewModels.Usuarios;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Repositories
{
    public interface IRepositorioUsuarios : IRepositorioGenerico<Usuarios>  
    {
        Task<Usuarios> Login(LoginViewModel objeto);

        bool ValidacionUsuarios(string nombre);
     
    }
}
