
using GestorPacientes.Core.Application.Interfaces.Services.Generics;
using GestorPacientes.Core.Application.ViewModels.Usuarios;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IServiciosUsuarios : IServiciosGenericos<SaveUsuariosViewModel, UsuariosViewModel, Usuarios>
    {
          Task<UsuariosViewModel> Login(LoginViewModel objeto);
         
          bool ValidacionUsuarios(string nombre);
    }
}
