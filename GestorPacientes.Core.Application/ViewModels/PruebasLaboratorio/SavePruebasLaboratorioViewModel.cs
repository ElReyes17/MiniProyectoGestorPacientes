

using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.PruebasLaboratorio
{
    public class SavePruebasLaboratorioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe Introducir el nombre de la prueba")]
        [DataType(DataType.Text)]
        public string TestName { get; set; } = null!;


        public List<PruebasLaboratorioViewModel>? Pruebas {get; set;}
    }
}
