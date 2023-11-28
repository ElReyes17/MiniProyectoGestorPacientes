

namespace GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio
{
    public class ResultadosLaboratorioViewModel
    {
        public int Id { get; set; }

        public int IdPacients { get; set; }

        public int IdLabTest { get; set; }

        public int IdResultState { get; set; }

        public int IdAppoimente { get; set; }

        public string Resultado { get; set; }

        public string PacientName { get; set; }

        public string PacientLastName { get; set; }

        public string? PacientCard {get; set; }

        public string TestName { get; set; }

        public string ResultStates { get; set; }

      


    }
}
