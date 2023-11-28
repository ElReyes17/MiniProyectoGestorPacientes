

using System.ComponentModel.DataAnnotations;

namespace GestorPacientes.Core.Application.ViewModels.Usuarios
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
       
      
        public string Name { get; set; } = null!;

       
        public string LastName { get; set; } = null!;


        
        public string Email { get; set; } = null!;

       
        public string UserName { get; set; } = null!;


        public string Password { get; set; } = null!;

        

        public string RolName { get; set; } = null!;


       


        

    }
}
