using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Medicos;
using Microsoft.AspNetCore.Mvc;
using MiniProyectoGestorPacientes.Middlewares;

namespace MiniProyectoGestorPacientes.Controllers
{
    public class MedicosController : Controller
    {
        private readonly IServiciosMedicos _servicios;
        private readonly ValidateUserSession _validateUserSession;

        public MedicosController(IServiciosMedicos servicios, ValidateUserSession validateUserSession)
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
            SaveMedicosViewModel model = new SaveMedicosViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveMedicosViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                return View("Create", vm);
            }

            SaveMedicosViewModel medicosvm =  await _servicios.Add(vm);
            if(medicosvm != null && medicosvm.Id != 0)
            {
                medicosvm.Photo = UploadFile(vm.File, vm.Id);
                await _servicios.Update(medicosvm); 
            }
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
        public async Task<IActionResult> EditPost(SaveMedicosViewModel editar)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Usuarios", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                return View("Create", editar);
            }

            SaveMedicosViewModel medicosvm = await _servicios.GetById(editar.Id);
            editar.Photo = UploadFile(editar.File, editar.Id, true, medicosvm.Photo);
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

        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath="")
        {
            if (isEditMode)
            {
                if(file == null)
                {
                    return imagePath;
                }
            }



            //obtener ruta directorio
            string basepath = $"/Images/Doctores/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basepath}");

            //crear carpeta si no existe
            if (!Directory.Exists(path))
            {
                
                Directory.CreateDirectory(path);

            }

            //obtener ruta del archivo
            Guid guid = Guid.NewGuid();
            FileInfo fileinfo = new(file.FileName);
            string filename = fileinfo.Name + fileinfo.Extension;

            string finalpath = Path.Combine(path, filename);

            using(var stream = new FileStream(finalpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine(basepath, filename);
        }
    }
}
