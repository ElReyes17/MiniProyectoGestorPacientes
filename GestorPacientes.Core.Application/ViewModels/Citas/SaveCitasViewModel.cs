

using GestorPacientes.Core.Application.ViewModels.Medicos;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Citas
{
    public class SaveCitasViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Introducir un paciente")]
        public int IdPacient { get; set; }

        [Required(ErrorMessage = "Debe Introducir un doctor")]
        public int IdDoctor { get; set; }

        
        public int IdState { get; set; }

        [Required(ErrorMessage = "Debe Introducir una Fecha")]
        public string Date { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir una Hora")]
        public string Time { get; set; } = null!;

        [Required(ErrorMessage = "Debe Introducir una Causa")]
        public string Cause { get; set; } = null!;

        public List<MedicosViewModel>? Doctors { get; set; } 

        public List<PacientesViewModel>? Pacients { get; set; }
        public List<string>? ResultState { get; set; } 

        public List<string>? TestName { get; set; } 
    }
}
