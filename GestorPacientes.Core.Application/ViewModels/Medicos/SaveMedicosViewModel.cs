
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Medicos
{
    public class SaveMedicosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Introducir el nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
      
        [Required(ErrorMessage = "Debe Introducir el Apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir el Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir el numero telefonico")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir la cedula")]
        public string CardNumber { get; set; } = null!;

        public string? Photo { get; set; } 

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; } 

    }
}
