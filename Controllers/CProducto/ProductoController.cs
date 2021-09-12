using ApiRestCliente.Controllers.CUsuarios;
using ApiRestCliente.Gestores;
using ApiRestCliente.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestCliente.Controllers.CProducto
{
    public class ProductoController : Controller 
    {
        private ListaDatos datos = UsuarioController.Datos; 
        public IActionResult Index()
        {
            datos.AgregarCategorias(GestorCategoria.ConsultarCategorias());
            return View(datos);
        }

        public IActionResult Categoria()
        {
            return View(datos);
        }
        public IActionResult CategoriaP2()
        {
            return View(datos);
        }


        //Metodos para manipular los datos
        public void AgregarCategoria(int a)
        {
            datos.AsignarCategoria(a);
        }

    }
}
