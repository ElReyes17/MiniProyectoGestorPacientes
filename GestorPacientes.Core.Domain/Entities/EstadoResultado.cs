
using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class EstadoResultado : EntidadBase
    {     
        public string ResultState { get; set; }
       
        //Navigation Properties
        public ICollection<ResultadosLaboratorio> LabResult { get; set; } = null!;
    }
}
