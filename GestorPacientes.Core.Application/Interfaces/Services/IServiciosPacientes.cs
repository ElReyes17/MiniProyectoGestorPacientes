using GestorPacientes.Core.Application.Interfaces.Services.Generics;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IServiciosPacientes : IServiciosGenericos<SavePacientesViewModel, PacientesViewModel, Pacientes>
    {

 
    }
}
