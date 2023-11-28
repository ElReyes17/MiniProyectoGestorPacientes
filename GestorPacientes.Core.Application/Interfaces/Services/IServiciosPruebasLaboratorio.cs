

using GestorPacientes.Core.Application.Interfaces.Services.Generics;
using GestorPacientes.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IServiciosPruebasLaboratorio : IServiciosGenericos<SavePruebasLaboratorioViewModel, PruebasLaboratorioViewModel, PruebasLaboratorio>
    {
    }
}
