

using GestorPacientes.Core.Domain.Common;
using System.Threading.Channels;

namespace GestorPacientes.Core.Domain.Entities
{
    public class Usuarios : EntidadPersona
    {
        
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string RoleName { get; set; } = null!; 

        
        
    }
}
