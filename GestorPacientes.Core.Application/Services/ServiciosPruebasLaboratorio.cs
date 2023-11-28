using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class ServiciosPruebasLaboratorio : IServiciosPruebasLaboratorio
    {
        private readonly IRepositorioPruebasLaboratorio _repository;

        public ServiciosPruebasLaboratorio(IRepositorioPruebasLaboratorio repository)
        {
            _repository = repository;
        }

       
        public async Task<List<PruebasLaboratorioViewModel>> GetAll()
        {
            var map = await _repository.GetAll();

            return map.Select(a => new PruebasLaboratorioViewModel
            {
                Id = a.Id,
                TestName = a.TestName,          

            }).ToList();
        }

        public Task<List<PruebasLaboratorioViewModel>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<SavePruebasLaboratorioViewModel> GetById(int id)
        {
            var map = await _repository.GetById(id);

            SavePruebasLaboratorioViewModel nuevo = new SavePruebasLaboratorioViewModel
            {
                Id = map.Id,
                TestName = map.TestName,             
            };

            return nuevo;
        }

        public async Task<SavePruebasLaboratorioViewModel> Add(SavePruebasLaboratorioViewModel objeto)
        {
            var add = new PruebasLaboratorio
            {
               TestName = objeto.TestName,

            };

            add = await _repository.Add(add);

            SavePruebasLaboratorioViewModel pacientesvm = new SavePruebasLaboratorioViewModel
            {
                Id = add.Id,
                TestName = objeto.TestName,

            };

            return pacientesvm;
        }

        public async Task Update(SavePruebasLaboratorioViewModel objeto)
        {
            PruebasLaboratorio a = await _repository.GetById(objeto.Id);


            a.Id = objeto.Id;
            a.TestName = objeto.TestName;

            await _repository.Update(a);
        }

        public async Task Delete(int id)
        {
           await _repository.Delete(id);
     
        }
    
    }

       

  }

