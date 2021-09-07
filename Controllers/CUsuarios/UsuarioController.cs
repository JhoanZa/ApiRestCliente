using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApiRestCliente.Models.MUsuarios;
using ConsoleApp1.Gestores;

namespace ApiRestCliente.Controllers.CUsuarios
{
    public class UsuarioController : Controller
    {
        private static Usuario usuario = new();
        public static Usuario Usuario { get => usuario; set => usuario = value; }

        public IActionResult Index()
        {
            if (!usuario.PrimerNombre.Contains("Visitante"))
            {
                return RedirectToAction(actionName:"Index", controllerName:"Home", usuario);
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(String correo, String contrasena)
        {
            if (correo != null && contrasena != null)
            {
                await Task.Run(() =>{ 
                    usuario = GestorUsuarios.ConsultarUsuario(correo);
                });
                if (usuario != null && usuario.Contrasena.Contains(contrasena))
                {
                    return RedirectToAction(actionName:"Index", controllerName:"Home", usuario);
                }
            }
            return View();
        }

        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearUsuario(
            [Bind("PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Correo,Contrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() =>
                {
                    usuario.Edad = CalcularEdad(usuario.FechaNacimiento);
                    GestorUsuarios.RegistrarUsuario(usuario);
                });
                return RedirectToAction(nameof(Index));
            }
           
            return View();
        }

        public IActionResult DatosPersonales()
        {
            return View(usuario);
        }

        public IActionResult DatosCredenciales()
        {
            return View(usuario);
        }
        public IActionResult DatosResidencia()
        {
            return View(usuario);
        }
        private static int CalcularEdad(DateTime date)
        {
            int edad = DateTime.Now.Year - date.Year;
            if (DateTime.Now.CompareTo(date) > 0)
            {
                return edad--;
            }
            return edad ;
        }

    }

}
