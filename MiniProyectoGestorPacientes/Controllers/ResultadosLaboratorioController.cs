using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using Microsoft.AspNetCore.Mvc;
using MiniProyectoGestorPacientes.Middlewares;

namespace MiniProyectoGestorPacientes.Controllers
{
    public class ResultadosLaboratorioController : Controller
    {
        private readonly IServiciosResultadosLaboratorio _serviciosResultados;
        private readonly IServiciosPacientes _serviciosPacientes;
        private readonly IServiciosPruebasLaboratorio _serviciosPruebas;
        private readonly IServiciosCitas _servicioCitas;
        private readonly IServiciosMedicos _serviciosMedicos;
        private readonly ValidateUserSession _validateUserSession;
        public ResultadosLaboratorioController(IServiciosResultadosLaboratorio serviciosResultados, IServiciosPacientes serviciosPacientes, IServiciosPruebasLaboratorio serviciosPruebas,
            IServiciosCitas servicioCitas, IServiciosMedicos serviciosMedicos, ValidateUserSession validateUserSession)
        {
            _serviciosResultados = serviciosResultados;
            _serviciosPacientes = serviciosPacientes;
            _serviciosPruebas = serviciosPruebas;
            _servicioCitas = servicioCitas;
            _serviciosMedicos = serviciosMedicos;
            _validateUserSession = validateUserSession;
        }
        public async Task<IActionResult> Index(FiltroPacientesViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            await _serviciosPruebas.GetAll();
             await _serviciosPacientes.GetAll();


            return View( await _serviciosResultados.GetWithFilters(vm));
        }


        public async Task<IActionResult> Reportar(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }

            return View(await _serviciosResultados.GetById(id));
     
        }

        [HttpPost]
        public async Task<IActionResult> PostReportar(SaveResultadosLaboratorioViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            await _serviciosPruebas.GetAll();
            await _serviciosMedicos.GetAll();
            await _serviciosPacientes.GetAll();          
            await _servicioCitas.GetAll();

            await _serviciosResultados.GetById(vm.Id);

            vm.IdResultState = 2;

            await _serviciosResultados.Update(vm);

            return RedirectToAction("Index");

        }
    }
}
