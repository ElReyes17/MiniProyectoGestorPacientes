using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Medicos;
using GestorPacientes.Core.Application.ViewModels.Pacientes;
using GestorPacientes.Core.Application.ViewModels.PruebasLaboratorio;
using Microsoft.AspNetCore.Mvc;
using MiniProyectoGestorPacientes.Middlewares;

namespace MiniProyectoGestorPacientes.Controllers
{
    public class PruebasLaboratorioController : Controller
    {
        private readonly IServiciosPruebasLaboratorio _servicios;
        private readonly ValidateUserSession _validateUserSession;
        public PruebasLaboratorioController(IServiciosPruebasLaboratorio servicios, ValidateUserSession validateUserSession)
        {
            _servicios = servicios;
            _validateUserSession = validateUserSession;
        }


        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            return View(await _servicios.GetAll());
        }

        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            SavePruebasLaboratorioViewModel model = new SavePruebasLaboratorioViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePruebasLaboratorioViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                return View("Create", vm);
            }

             await _servicios.Add(vm);
           
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            return View("Create", await _servicios.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(SavePruebasLaboratorioViewModel editar)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                return View("Create", editar);
            }
     
            await _servicios.GetById(editar.Id);
           
            await _servicios.Update(editar);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
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

       
    }
}
