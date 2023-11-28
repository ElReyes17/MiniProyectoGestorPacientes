

using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPacientes.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestorPacientes.Core.Application.ViewModels.Citas
{
    public class CitasViewModel
    {
        public int Id { get; set; }

        public int IdPacient { get; set; }

        public int IdDoctor { get; set; }

        public int IdState { get; set; }

        public string? PacientName { get; set; }

        public string? DoctorName { get; set; }

        public string Date { get; set; } = null!;

        public string Time { get; set; } = null!;

        public string Cause { get; set; } = null!;

        public string AppointmentState { get; set; } = null!;

        public string?  ResultStates { get; set; }


        public string?  TestName {get; set; }     


   
    }
}
