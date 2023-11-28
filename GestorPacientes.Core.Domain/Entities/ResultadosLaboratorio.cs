using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class ResultadosLaboratorio : EntidadBase
    {
        public int IdPacient {get; set;} 

        public int IdLabTest {get; set;}

        public int IdResultState { get; set; }

        public int IdAppoiments { get; set;}

        public string? Resultado {get; set;}

   
        
        //Navigation Properties
        public Pacientes Pacient { get; set; } = null!;

        public PruebasLaboratorio LabTest { get; set; } = null!;

        public EstadoResultado ResultState { get; set; } = null!;

        public Citas Appoiments { get; set; } = null!;
    }
}
