
using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
   public class PruebasLaboratorio : EntidadBase
    {

       public string TestName { get; set; } = null!;

      public ICollection<ResultadosLaboratorio> LabResult { get; set; } = null!;
       
    }
}
