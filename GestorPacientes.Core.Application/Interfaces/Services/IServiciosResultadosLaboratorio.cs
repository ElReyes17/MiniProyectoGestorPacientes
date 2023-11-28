using GestorPacientes.Core.Application.Interfaces.Services.Generics;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IServiciosResultadosLaboratorio : IServiciosGenericos<SaveResultadosLaboratorioViewModel, ResultadosLaboratorioViewModel, ResultadosLaboratorio>
    {
        Task<List<ResultadosLaboratorioViewModel>> GetByCitas(int id);


        Task<List<ResultadosLaboratorioViewModel>> GetWithFilters(FiltroPacientesViewModel filtro);

    }
        
}
