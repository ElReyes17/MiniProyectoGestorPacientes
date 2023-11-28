

using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Application.ViewModels.PruebasLaboratorio;
using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio
{
    public class SaveResultadosLaboratorioViewModel
    {
        public int Id { get; set; }

        public int IdPacients { get; set; }

        public int IdLabTest {get; set; }

        public int IdResultState { get; set; }

        public int IdCita {get; set; }

        public string? Resultado { get; set; } 


        [Range(1,int.MaxValue, ErrorMessage = "Debe Colocar una prueba")]
      
        public List<int> Pruebas { get; set; }

        public List<PruebasLaboratorioViewModel>? LabTest { get; set; }
       
    }
}
