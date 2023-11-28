using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class ServiciosPacientes : IServiciosPacientes
    {
        private readonly IRepositorioPacientes _repository;
        public ServiciosPacientes(IRepositorioPacientes repository)
        {
            _repository = repository;
        }

        public async Task<List<PacientesViewModel>> GetAll()
        {
            var map = await _repository.GetAll();

            return map.Select(a => new PacientesViewModel
            {
                Id = a.Id,
                Name = a.Name,
                LastName = a.LastName,
                CardNumber = a.CardNumber,
                PhoneNumber = a.PhoneNumber,
                Photo = a.Photo,
                Email = a.Email,
                BirthDate = a.BirthDate,
                Smoke = a.Smoke,
                Alergy = a.Alergy,
                Adress = a.Adress,     

            }).ToList();
        }

        public Task<List<PacientesViewModel>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

       

        public async Task<SavePacientesViewModel> GetById(int id)
        {
            var map = await _repository.GetById(id);

            SavePacientesViewModel nuevo = new SavePacientesViewModel
            {
                Id = map.Id,
                Name = map.Name,
                LastName = map.LastName,
                CardNumber = map.CardNumber,
                PhoneNumber = map.PhoneNumber,
                Photo = map.Photo,
                Email = map.Email,
                BirthDate = map.BirthDate,
                Smoke = map.Smoke,
                Alergy = map.Alergy,
                Adress = map.Adress,

            };

            return nuevo;
        }

        public async Task<SavePacientesViewModel> Add(SavePacientesViewModel objeto)
        {
            var add = new Pacientes
            {
                Name = objeto.Name,
                LastName = objeto.LastName,
                CardNumber = objeto.CardNumber,
                PhoneNumber = objeto.PhoneNumber,
                Adress = objeto.Adress,
                Photo = objeto.Photo,
                Email = objeto.Email,
                BirthDate = objeto.BirthDate,
                Smoke = objeto.Smoke,
                Alergy = objeto.Alergy,

            };

            add = await _repository.Add(add);

            SavePacientesViewModel pacientesvm = new SavePacientesViewModel
            {
                Id = add.Id,
                Name = add.Name,
                LastName = add.LastName,
                CardNumber = add.CardNumber,
                PhoneNumber = add.PhoneNumber,
                Photo = add.Photo,
                Email = add.Email,
                BirthDate =add.BirthDate,
                Smoke = add.Smoke,
                Alergy = add.Alergy,

            };

            return pacientesvm;
        }

        public async Task Update(SavePacientesViewModel objeto)
        {
            Pacientes a = await _repository.GetById(objeto.Id);


            a.Id = objeto.Id;
            a.Name = objeto.Name;
            a.LastName = objeto.LastName;
            a.CardNumber = objeto.CardNumber;
            a.PhoneNumber = objeto.PhoneNumber;
            a.Photo = objeto.Photo;
            a.Email = objeto.Email;
            a.BirthDate = objeto.BirthDate;
            a.Smoke = objeto.Smoke;
            a.Alergy = objeto.Alergy;


            await _repository.Update(a);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

    }
}
