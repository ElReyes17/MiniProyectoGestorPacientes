
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Usuarios
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Debe Introducir el Usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }


        [Required(ErrorMessage = "Debe Introducir la contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
   

    }
}
