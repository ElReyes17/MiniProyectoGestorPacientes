using Microsoft.AspNetCore.Mvc;
using MiniProyectoGestorPacientes.Middlewares;
using MiniProyectoGestorPacientes.Models;
using System.Diagnostics;

namespace MiniProyectoGestorPacientes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ValidateUserSession _validateUserSession;
        public HomeController(ValidateUserSession validateUserSession)
        {
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            return View();
        }

        

       
    }
}