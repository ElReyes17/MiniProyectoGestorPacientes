using GestorPacientes.Core.Application.ViewModels.Usuarios;
using GestorPacientes.Core.Application.Helpers;
using Microsoft.AspNetCore.Http;

namespace MiniProyectoGestorPacientes.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            UsuariosViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UsuariosViewModel>("user");

            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }

    }
}
