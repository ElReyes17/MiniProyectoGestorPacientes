
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPacientes.Core.Application.ViewModels.Usuarios;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class ServiciosUsuarios : IServiciosUsuarios
    {
        private readonly IRepositorioUsuarios _repository;
        public ServiciosUsuarios(IRepositorioUsuarios repository)
        {
           _repository = repository;
        }

        public async Task<List<UsuariosViewModel>> GetAll()
        {
            var map = await _repository.GetAll();


            return map.Select(a => new UsuariosViewModel
            {
                Id = a.Id,
                Name = a.Name,
                LastName = a.LastName,
                Email = a.Email,
                UserName = a.UserName,
                Password = a.Password,
                RolName = a.RoleName

            }).ToList();
        }

        public async Task<List<UsuariosViewModel>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<SaveUsuariosViewModel> GetById(int id)
        {
            var map = await _repository.GetById(id);

            SaveUsuariosViewModel nuevo = new SaveUsuariosViewModel
            {
                Id = map.Id,
                Name = map.Name,
                LastName = map.LastName, 
                Email= map.Email,
                UserName = map.UserName,
                Password = map.Password,
                RoleName = map.RoleName
                
            };

            return nuevo;
        }

        public async Task<SaveUsuariosViewModel> Add(SaveUsuariosViewModel objeto)
        {
            var add = new Usuarios
            {
              
                Name = objeto.Name,
                LastName = objeto.LastName,
                Email = objeto.Email,
                UserName = objeto.UserName,
                Password = objeto.Password,
                RoleName = objeto.RoleName


            };

            add = await _repository.Add(add);

            SaveUsuariosViewModel pacientesvm = new SaveUsuariosViewModel
            {
                Id = add.Id,
               Name = add.Name,
               LastName = add.LastName,
               Email = add.Email,
               UserName = add.UserName,
               Password = add.Password,
               RoleName = add.RoleName
                

            };

            return pacientesvm;
        }
        public async Task<UsuariosViewModel> Login(LoginViewModel objeto)
        {
            Usuarios a = await _repository.Login(objeto);

            if(a == null)
            {
                return null;
            }

            UsuariosViewModel usuariovm = new UsuariosViewModel();

            usuariovm.Id = a.Id;
            usuariovm.Name = a.Name;
            usuariovm.LastName = a.LastName;
            usuariovm.Email = a.Email;
            usuariovm.UserName = a.UserName;
            usuariovm.Password = a.Password;
            usuariovm.RolName = a.RoleName;      

            return usuariovm;
        }
        public async Task Update(SaveUsuariosViewModel objeto)
        {
            Usuarios a = await _repository.GetById(objeto.Id);


            a.Id = objeto.Id;
            a.Name = objeto.Name;
            a.LastName = objeto.LastName;
            a.Email = objeto.Email;
            a.UserName = objeto.UserName;
            a.Password = objeto.Password;
            a.RoleName = objeto.RoleName;


            await _repository.Update(a);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public bool ValidacionUsuarios(string nombre)
        {
            return _repository.ValidacionUsuarios(nombre);
        }

    }
}
