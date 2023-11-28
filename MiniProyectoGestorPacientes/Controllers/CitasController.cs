using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Citas;
using GestorPacientes.Core.Application.ViewModels.PruebasLaboratorio;
using GestorPacientes.Core.Application.ViewModels.ResultadosLaboratorio;
using Microsoft.AspNetCore.Mvc;
using MiniProyectoGestorPacientes.Middlewares;

namespace MiniProyectoGestorPacientes.Controllers
{
    public class CitasController : Controller
    {
        private readonly IServiciosCitas _servicios;
        private readonly IServiciosPacientes _serviciosPacientes;
        private readonly IServiciosMedicos _serviciosMedicos;
        private readonly IServiciosPruebasLaboratorio _serviciosPruebasLaboratorio;
        private readonly IServiciosResultadosLaboratorio _serviciosResultados;
        private readonly ValidateUserSession _validateUserSession;

        public CitasController(IServiciosCitas servicios, IServiciosPacientes serviciosPacientes, IServiciosMedicos serviciosMedicos, 
            IServiciosPruebasLaboratorio serviciosPruebasLaboratorio, IServiciosResultadosLaboratorio serviciosResultados, ValidateUserSession validateUserSession)
        {
            _servicios = servicios;
            _serviciosPacientes = serviciosPacientes;
            _serviciosMedicos = serviciosMedicos;
            _serviciosPruebasLaboratorio = serviciosPruebasLaboratorio;
            _serviciosResultados = serviciosResultados;
            _validateUserSession = validateUserSession;
        }


        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            await _serviciosMedicos.GetAll();
            await _serviciosPacientes.GetAll();
            await _serviciosPruebasLaboratorio.GetAll();
            await _serviciosResultados.GetAll();
            return View(await _servicios.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            SaveCitasViewModel model = new SaveCitasViewModel();

            model.Pacients = await _serviciosPacientes.GetAll();
            model.Doctors = await _serviciosMedicos.GetAll();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCitasViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            vm.IdState = 1;

            if (!ModelState.IsValid)
            {
                vm.Doctors = await _serviciosMedicos.GetAll();
                vm.Pacients = await _serviciosPacientes.GetAll();

                return View("Create", vm);
            } 

            await _servicios.Add(vm);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {   if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            return View(await _servicios.GetById(id));
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            await _servicios.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Pruebas(int id, int id2)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            SaveResultadosLaboratorioViewModel prueba = new SaveResultadosLaboratorioViewModel();

            prueba.IdPacients = id;

            prueba.IdCita = id2;

            await _serviciosPacientes.GetById(id);

            await _servicios.GetById(id2);


            prueba.LabTest = await _serviciosPruebasLaboratorio.GetAll();

            return View(prueba);

        }

        [HttpPost]

        public async Task<IActionResult> PruebasPost(SaveResultadosLaboratorioViewModel results, int idcita)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }

            results.IdResultState = 1;


            SaveCitasViewModel vm = new SaveCitasViewModel();

            vm = await _servicios.GetById(idcita);

            vm.IdState = 2;

            await _servicios.Update(vm);

            foreach (var item in results.Pruebas)
            {
              
                results.IdCita = idcita;
                results.IdLabTest = item;
                await _serviciosResultados.Add(results);
            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Resultados(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            await _serviciosMedicos.GetAll();
            await _serviciosPacientes.GetAll();
            await _serviciosPruebasLaboratorio.GetAll();
            await _servicios.GetAll();
            await _servicios.GetById(id);
       
            return View(await _serviciosResultados.GetByCitas(id));
        }

        public async Task<IActionResult> Completado(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            SaveCitasViewModel vm = new SaveCitasViewModel();

            vm = await _servicios.GetById(id);

            vm.IdState = 3;

            await _servicios.Update(vm);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> VeResultados(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            await _serviciosMedicos.GetAll();
            await _serviciosPacientes.GetAll();
            await _serviciosPruebasLaboratorio.GetAll();
            await _servicios.GetAll();
            await _servicios.GetById(id);

            return View(await _serviciosResultados.GetByCitas(id));


        }


    }
}
