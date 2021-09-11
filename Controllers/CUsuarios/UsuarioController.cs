﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApiRestCliente.Models.MUsuarios;
using ApiRestCliente.Models;
using ApiRestCliente.Gestores;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (!datos.PrimerNombre.Contains("Visitante"))
            {
                return RedirectToAction(actionName:"Index", controllerName:"Home", datos);
            }
            return View(datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(String correo, String contrasena)
        {
            if (correo != null && contrasena != null)
            {
                await Task.Run(() =>{ 
                    Usuario Usuario = GestorUsuarios.ConsultarUsuario(correo);
                    datos.CrearUsuario(Usuario);
                });
                if (datos != null && datos.Contrasena.Contains(contrasena))
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

            datos.PrimerNombre = PrimerNombre;
            datos.SegundoNombre = SegundoNombre ?? "";
            datos.PrimerApellido = PrimerApellido;
            datos.SegundoApellido = SegundoApellido ?? "";
            await Task.Run(() =>
            {
                realizado = GestorUsuarios.ModificarUsuario(datos.GenerarUsuario());
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
            datos.Contrasena = Contrasena;
            await Task.Run(() =>
            {
                realizado = GestorUsuarios.ModificarUsuario(datos.GenerarUsuario());
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
                datos.Contrasena = usuarioP.Contrasena;
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
