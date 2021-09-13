using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApiRestCliente.Models.MUsuarios;
using ApiRestCliente.Models;
using ApiRestCliente.Gestores;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiRestCliente.Models.MDomicilios;

namespace ApiRestCliente.Controllers.CUsuarios
{
    public class UsuarioController : Controller
    {
        //private static Usuario usuario = new();
        //public static Usuario Usuario { get => usuario; set => usuario = value; }

        private static ListaDatos datos = new();
        public static ListaDatos Datos { get => datos; set => datos = value; }

        public IActionResult Index()
        {
            if (!datos.Usuario.PrimerNombre.Contains("Visitante"))
            {
                return RedirectToAction(actionName:"Index", controllerName:"Home", datos);
            }
            return View(datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(String Correo, String Contrasena)
        {
            if (Correo != null && Contrasena != null)
            {
                await Task.Run(() =>{
                    datos.Usuario = GestorUsuarios.ConsultarUsuario(Correo);
                    List<Domicilio> Domicilio = GestorDomicilios.ConsultarDomicilio(Correo);
                    foreach (Domicilio domicilio in Domicilio)
                    {
                            datos.CrearDomicilio(domicilio);
                    }
                });
                if (datos != null && datos.Usuario.Contrasena.Contains(Contrasena))
                {
                    return RedirectToAction(actionName:"Index", controllerName:"Home", datos);
                }
            }
            return View();
        }

        public IActionResult CrearUsuario()
        {
            return View(datos);
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

        public IActionResult InfoUsuario()
        {
            return View(datos);
        }
        public IActionResult DatosPersonales()
        {
            return View(datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DatosPersonales(String PrimerNombre, String SegundoNombre, String PrimerApellido, String SegundoApellido)
        {
            bool realizado = false;

            datos.Usuario.PrimerNombre = PrimerNombre;
            datos.Usuario.SegundoNombre = SegundoNombre ?? "";
            datos.Usuario.PrimerApellido = PrimerApellido;
            datos.Usuario.SegundoApellido = SegundoApellido ?? "";
            await Task.Run(() =>
            {
                realizado = GestorUsuarios.ModificarUsuario(datos.Usuario);
            });
            if (realizado)
            {
                return View("InfoUsuario",datos);
            }
            return View(datos);
            
        }

        public IActionResult DatosCredenciales()
        {
            return View(datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DatosCredenciales(String Contrasena)
        {
            bool realizado = false;
            datos.Usuario.Contrasena = Contrasena;
            await Task.Run(() =>
            {
                realizado = GestorUsuarios.ModificarUsuario(datos.Usuario);
            });
            if (realizado)
            {
                return View("InfoUsuario",datos);
            }
            return View(datos);

        }

        public IActionResult DatosResidenciaP2()
        {
            return View(datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DatosResidenciaP2(String Direccion)
        {   
            bool realizado = false;
            datos.Domicilio.Direccion = Direccion;
            await Task.Run(() =>
            {   
                if (datos.Domicilio.Id != 0)
                {
                    realizado = GestorDomicilios.ModificarDomicilio(datos.Domicilio);
                }
                else
                {
                    realizado = GestorDomicilios.RegistrarDomicilio(datos.Domicilio);
                }
            });
            if (realizado)
            {
                return View("InfoUsuario",datos);
            }
            return View(datos);

        }

        public IActionResult DatosResidencia()
        {
            datos.AgregarDepartamento(GestorMunicipios.ConsultarDepartamento());
            return View(datos);
        }
     
        public IActionResult Salir()
        {
            datos.EliminarUsuario();
            return RedirectToAction(actionName: "Index", controllerName: "Home", datos);
        }

        public IActionResult RecuperarContrasena()
        {
            return View(datos);
        }
        [HttpPost]
        public async Task<IActionResult> RecuperarContrasena(String Correo)
        {
            await Task.Run(() =>
            {
                Usuario usuarioP = GestorUsuarios.ConsultarUsuario(Correo);
                datos.Usuario.Contrasena = usuarioP.Contrasena;
            });
            return View(datos);
        }

        //Metodos que solo manipulan datos
        [HttpGet]
        public void ListaMunicipios(int a)
        {
            datos.AgregarMunicipios(GestorMunicipios.ConsultarMunicipios(a));
            datos.AsignarDepartamento(a);
        }
        public void ObtenerMunicipio(int a)
        {
            datos.AsignarMunicipio(a);
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
