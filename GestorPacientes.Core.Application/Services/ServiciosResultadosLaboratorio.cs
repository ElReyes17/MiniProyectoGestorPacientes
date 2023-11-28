
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class ServiciosResultadosLaboratorio : IServiciosResultadosLaboratorio
    {
        private readonly IRepositorioResultadosLaboratorio _repository;
        private readonly IRepositorioEstadoResultado _estado;
        public ServiciosResultadosLaboratorio(IRepositorioResultadosLaboratorio repository, IRepositorioEstadoResultado estado)
        {
            _repository = repository;   
            _estado = estado;
        }

        public async Task<List<ResultadosLaboratorioViewModel>> GetAll()
        {
            var map = await _repository.GetAll();
            await _estado.GetAll();

            return map.Select(a => new ResultadosLaboratorioViewModel
            {
                Id = a.Id,
                IdLabTest = a.IdLabTest,
                IdPacients = a.IdPacient,
                IdResultState = a.IdResultState,
                IdAppoimente = a.IdAppoiments,
                PacientName = a.Pacient.Name,
                PacientLastName = a.Pacient.LastName,
                PacientCard = a.Pacient.CardNumber,
                TestName = a.LabTest.TestName,
                ResultStates = a.ResultState.ResultState
                
            }).ToList();
        }

        public async Task<List<ResultadosLaboratorioViewModel>> GetByCitas(int id)
        {
            var map = await _repository.GetAll();
            await _estado.GetAll();

            map = map.Where(a => a.IdAppoiments == id).ToList();

            return map.Select(a => new ResultadosLaboratorioViewModel
            {
                Id = a.Id,
                IdLabTest = a.IdLabTest,
                IdPacients = a.IdPacient,
                IdResultState = a.IdResultState,
                IdAppoimente = a.IdAppoiments,
                PacientName = a.Pacient.Name,
                PacientLastName = a.Pacient.LastName,
                PacientCard = a.Pacient.CardNumber,
                TestName = a.LabTest.TestName,
                ResultStates = a.ResultState.ResultState,
                Resultado = a.Resultado


            }).ToList();


        }

        public async Task<List<ResultadosLaboratorioViewModel>> GetWithFilters(FiltroPacientesViewModel filtro)
        {

            var map = await _repository.GetAllWithInclude(new List<string>{"Pacient"});
            await _estado.GetAll();

            var lista = map.Select(a => new ResultadosLaboratorioViewModel
            {
               
                Id = a.Id,
                IdLabTest = a.IdLabTest,
                IdPacients = a.IdPacient,
                IdResultState = a.IdResultState,
                IdAppoimente = a.IdAppoiments,
                PacientName = a.Pacient.Name,
                PacientLastName = a.Pacient.LastName,
                PacientCard = a.Pacient.CardNumber,
                TestName = a.LabTest.TestName,
                ResultStates = a.ResultState.ResultState,
                Resultado = a.Resultado


            }).ToList();

            if (filtro.CardNumber != null)
            {
                lista = lista.Where(a => a.PacientCard == filtro.CardNumber.ToString()).ToList();
            }

            return lista;
        }
        public Task<List<ResultadosLaboratorioViewModel>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<SaveResultadosLaboratorioViewModel> GetById(int id)
        {
           
             var map = await _repository.GetById(id);
             

            SaveResultadosLaboratorioViewModel nuevo = new SaveResultadosLaboratorioViewModel
            {
                Id = map.Id,
                IdLabTest = map.IdLabTest,
                IdCita = map.IdAppoiments,
                IdPacients = map.IdPacient,
                IdResultState = map.IdResultState,
                Resultado = map.Resultado,
               
                      
            };

            return nuevo;


        }
        public async Task<SaveResultadosLaboratorioViewModel> Add(SaveResultadosLaboratorioViewModel objeto)
        {
              var add = new ResultadosLaboratorio
            {
                  IdLabTest = objeto.IdLabTest,
                  IdPacient = objeto.IdPacients,
                  IdResultState = objeto.IdResultState,
                  IdAppoiments = objeto.IdCita,
                  Resultado = objeto.Resultado,

            
            };

            add = await _repository.Add(add);

            SaveResultadosLaboratorioViewModel pacientesvm = new SaveResultadosLaboratorioViewModel
            {
                Id = add.Id,
                IdPacients = add.IdPacient,
                IdResultState = add.IdResultState,
                IdLabTest = add.IdLabTest,
                IdCita = add.IdAppoiments,
                Resultado = objeto.Resultado

            };

            return pacientesvm;
        }

        public async Task Update(SaveResultadosLaboratorioViewModel objeto)
        {
            ResultadosLaboratorio a = await _repository.GetById(objeto.Id);

            a.Resultado = objeto.Resultado;
            a.IdResultState = objeto.IdResultState;

            await _repository.Update(a);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
