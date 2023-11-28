
using GestorPacientes.Core.Application.Interfaces.Services.Generics;
using GestorPacientes.Core.Application.ViewModels.Citas;
using GestorPacientes.Core.Application.ViewModels.Usuarios;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IServiciosCitas : IServiciosGenericos<SaveCitasViewModel, CitasViewModel, Citas>
    {

    }
}
