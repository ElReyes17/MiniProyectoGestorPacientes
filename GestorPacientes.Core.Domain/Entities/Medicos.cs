

using GestorPacientes.Core.Domain.Common;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Medicos : EntidadPersona
    {
       
        public string PhoneNumber { get; set; } = null!; 

        public string CardNumber { get; set; } = null!;

        public string? Photo {get; set; } 

      
        
        //Navegation Properties 

        public ICollection<Citas> Citas { get; set; } = null!;


    }
}
