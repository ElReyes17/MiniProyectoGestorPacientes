using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Pacientes
{
    public class PacientesViewModel
    {
        public int Id { get; set; }
 
        public string Name { get; set; } = null!;
   
        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Adress { get; set; } = null!; 

        public string PhoneNumber { get; set; } = null!;

        public string CardNumber { get; set; } = null!;

        public string BirthDate { get; set; } = null!;

        public bool Smoke { get; set; }

        public bool Alergy { get; set; }

        public string? Photo { get; set; }
    }
}
