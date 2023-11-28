
using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Citas : EntidadBase
    {   
        public int IdPacient { get; set; }

        public int IdDoctor { get; set; }

        public int IdState { get; set; }

        public string Date { get; set; } = null!;

        public string Time { get; set; } = null!;

        public string Cause { get; set; } = null!;

        

        //Navegation Properties 

        public Pacientes Pacient { get; set; } = null!;

        public Medicos Doctor { get; set; } = null!;

        public EstadoCita AppointmentState { get; set; } = null!;

        public ICollection<ResultadosLaboratorio> LabResults { get; set; } 

        


    }
}
