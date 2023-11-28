
using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Pacientes : EntidadPersona
    {


        public string PhoneNumber { get; set; } = null!;

        public string CardNumber { get; set; } = null!;

        public string Adress { get; set; } = null!;

        public string BirthDate { get; set; } = null!;

        public bool Smoke { get; set; }

        public bool Alergy { get; set; }

        public string? Photo { get; set; } = null!;


        //Navegation Properties 

        public ICollection<Citas> Citas { get; set; } = null!;

        public ICollection<ResultadosLaboratorio> LabResult {get; set;} = null!;
    }
}
