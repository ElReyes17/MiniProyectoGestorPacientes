using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Citas;
using GestorPacientes.Core.Domain.Entities;
using System.Security.AccessControl;

namespace GestorPacientes.Core.Application.Services
{
    public class ServiciosCitas : IServiciosCitas
    {

        private readonly IRepositorioCitas _repository; 
        private readonly IRepositorioEstadoCita _estado;
        private readonly IRepositorioEstadoResultado _estadoresult;
        public ServiciosCitas(IRepositorioCitas repository, IRepositorioEstadoCita estado, IRepositorioEstadoResultado estadoresult)
        {
            _repository = repository;
            _estado = estado;
            _estadoresult = estadoresult;
        }
        public async  Task<List<CitasViewModel>> GetAll()
        {
            var map = await _repository.GetAllWithInclude(new List<string> { "AppointmentState", "Pacients", "Doctors", "LabResults", "ResultState" });

            await _estado.GetAll();
            await _estadoresult.GetAll();

            return map
      .Select(a => new CitasViewModel
      {
          Id = a.Id,
          IdPacient = a.IdPacient,
          IdDoctor = a.IdDoctor,
          IdState = a.IdState,
          Cause = a.Cause,
          Date = a.Date,
          Time = a.Time,
          PacientName = a.Pacient.Name,
          DoctorName = a.Doctor.Name,
          AppointmentState = a.AppointmentState.AppointmentState,
               
          
      })
      .ToList();

        }

        public Task<List<CitasViewModel>> GetAllWithInclude()
        {
            throw new NotImplementedException();
        }

        public async Task<SaveCitasViewModel> GetById(int id)
        {
            var map = await _repository.GetById(id);

            SaveCitasViewModel nuevo = new SaveCitasViewModel
            {
                Id = map.Id,
                IdPacient = map.IdPacient,
                IdDoctor = map.IdDoctor,
                IdState = map.IdState,
                Cause = map.Cause,
                Date = map.Date,
                Time = map.Time,
                ResultState = map.LabResults != null ? map.LabResults.Where(a => a.IdAppoiments == id).Select(a => a.ResultState.ResultState).ToList() : null,
                TestName = map.LabResults != null ? map.LabResults.Where(a => a.IdAppoiments == id).Select(a => a.LabTest.TestName).ToList() : null,




            };
            
            return nuevo;
        }

        public async Task<SaveCitasViewModel> Add(SaveCitasViewModel objeto)
        {
         
            var add = new Citas
            {
                IdPacient = objeto.IdPacient,
                IdDoctor = objeto.IdDoctor,
                IdState = objeto.IdState,
                Cause = objeto.Cause,
                Date = objeto.Date,
                Time = objeto.Time,

            };

            add = await _repository.Add(add);

            SaveCitasViewModel citasvm = new SaveCitasViewModel
            {
                Id = add.Id,
                IdPacient = add.IdPacient,
                IdDoctor = add.IdDoctor,
                IdState = add.IdState,
                Cause = add.Cause,
                Date = add.Date,
                Time = add.Time,

            };

            return citasvm;
        }

        public async Task Update(SaveCitasViewModel objeto)
        {
            Citas a = await _repository.GetById(objeto.Id);

            a.IdState = objeto.IdState;
            
       await _repository.Update(a);

        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

    
    }
}
