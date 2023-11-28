using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.Pacientes
{
    public class SavePacientesViewModel
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

        public string Adress { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir el numero telefonico")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir la cedula")]
        public string CardNumber { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir fecha de nacimiento")]
        public string BirthDate { get; set; } = null!;

        public bool Smoke { get; set; }

        public bool Alergy { get; set; }

        public string? Photo { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
    }
}
