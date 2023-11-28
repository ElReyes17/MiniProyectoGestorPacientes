using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Domain.Entities;
using MiniProyectoGestorPacientes.Middlewares;

namespace MiniProyectoGestorPacientes.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IServiciosUsuarios _services;
        private readonly ValidateUserSession _validateUserSession;

        public UsuariosController(IServiciosUsuarios services, ValidateUserSession validateUserSession)
        {
            _services = services;
            _validateUserSession = validateUserSession;
        }


        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            return View(await _services.GetAll());
        }

        public async Task<IActionResult> Login()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            return View();
        }

            [HttpPost]
         public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return  View(vm);
            }

            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }

            UsuariosViewModel usuariosvm = await _services.Login(vm);

            if(usuariosvm != null)
            {
                HttpContext.Session.Set<UsuariosViewModel>("user", usuariosvm);
                return RedirectToRoute(new { controller = "Home", Action = "Index" });

            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso Incorrectos");
            }

            return View(vm);
            
        }

      


        public IActionResult Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            SaveUsuariosViewModel model = new SaveUsuariosViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveUsuariosViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                return View("Create", vm);
            }
            if (_services.ValidacionUsuarios(vm.UserName))
            {
                ModelState.AddModelError("userValidation", "El usuario ya existe");
                return View(vm);
            }

               await _services.Add(vm);
            
            return RedirectToAction("Index");

        }

        public IActionResult Register()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            SaveUsuariosViewModel model = new SaveUsuariosViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUsuariosViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", vm);
            }
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            if (_services.ValidacionUsuarios(vm.UserName))
            {
                ModelState.AddModelError("userValidation", "El usuario ya existe");
                return View(vm);
            }

            await _services.Add(vm);

            return RedirectToAction("Login");

        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }

            return View("Create", await _services.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(SaveUsuariosViewModel editar)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                return View("Create", editar);
            }

            await _services.GetById(editar.Id);

            await _services.Update(editar);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            return View(await _services.GetById(id));
        }


        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            await _services.Delete(id);
            return RedirectToAction("Index");
        }
      
        public IActionResult Finish()
        {

            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");

        }





    }
}
