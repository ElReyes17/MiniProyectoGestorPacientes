using GestorPacientes.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Domain.Entities
{
  public class EstadoCita : EntidadBase
    { 

        public string AppointmentState { get; set; } = null!;


        //Navegation Properties
        public ICollection<Citas> Citas { get; set; } = null!;


    }
}
