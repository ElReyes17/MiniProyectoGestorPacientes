
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Usuarios
{
    public class SaveUsuariosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Introducir el nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir el Apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir el Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir el Usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = null!;

      
        [Required(ErrorMessage = "Debe Introducir la contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben coincidir")]
        [Required(ErrorMessage = "Debe repetir la contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage ="Seleccione un tipo de usuario")]
        public string RoleName { get; set; } = null!;

    }
}
