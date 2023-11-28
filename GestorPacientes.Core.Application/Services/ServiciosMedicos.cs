
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Medicos;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class ServiciosMedicos : IServiciosMedicos
    {
        private readonly IRepositorioMedicos _repository;
        public ServiciosMedicos(IRepositorioMedicos repository)
        {
            _repository = repository;
        }
        public async Task<List<MedicosViewModel>> GetAll()
        {
            var map = await _repository.GetAll();

            return map.Select(a => new MedicosViewModel
            {
                Id = a.Id,
                Name = a.Name,
                LastName = a.LastName,
                CardNumber = a.CardNumber,
                PhoneNumber = a.PhoneNumber,
                Photo = a.Photo,
                Email = a.Email,

            }).ToList();
        }

        public Task<List<MedicosViewModel>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<SaveMedicosViewModel> GetById(int id)
        {
            var map = await _repository.GetById(id);

            SaveMedicosViewModel nuevo = new SaveMedicosViewModel
            {
                Id = map.Id, 
                Name = map.Name,
                LastName = map.LastName,
                CardNumber = map.CardNumber,
                PhoneNumber = map.PhoneNumber,
                Photo = map.Photo,
                Email = map.Email,

            };

            return nuevo;
        }

        public async Task<SaveMedicosViewModel> Add(SaveMedicosViewModel objeto)
        {
            var add = new Medicos
            {          
                Name = objeto.Name,
                LastName = objeto.LastName,
                CardNumber = objeto.CardNumber,
                PhoneNumber = objeto.PhoneNumber,
                Photo = objeto.Photo,
                Email = objeto.Email,

            };

              add = await _repository.Add(add);

            SaveMedicosViewModel medicosvm = new SaveMedicosViewModel
            {
                Id = add.Id,
                Name = add.Name,
                LastName = add.LastName,
                CardNumber = add.CardNumber,
                PhoneNumber = add.PhoneNumber,
                Photo = add.Photo,
                Email = add.Email,

            };

            return medicosvm;

        }

        public async Task Update(SaveMedicosViewModel objeto)
        {
            Medicos a = await _repository.GetById(objeto.Id);


                a.Id = objeto.Id;
                a.Name = objeto.Name;
                a.LastName = objeto.LastName;
                a.CardNumber = objeto.CardNumber;
                a.PhoneNumber = objeto.PhoneNumber;
                a.Photo = objeto.Photo;
                a.Email = objeto.Email;

            

            await _repository.Update(a);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);   
        }

        
    }
}
