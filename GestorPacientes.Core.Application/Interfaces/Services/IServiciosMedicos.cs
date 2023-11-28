

using GestorPacientes.Core.Application.Interfaces.Services.Generics;
using GestorPacientes.Core.Application.ViewModels.Medicos;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IServiciosMedicos : IServiciosGenericos<SaveMedicosViewModel, MedicosViewModel, Medicos>
    {

    }
}
