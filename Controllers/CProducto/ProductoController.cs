using ApiRestCliente.Controllers.CUsuarios;
using ApiRestCliente.Gestores;
using ApiRestCliente.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CategoriaP2(string NombreProducto, string Descripcion, int CantidadDisponible, decimal ValorVenta)
        //{

        //}


        //Metodos para manipular los datos
        public void AgregarCategoria(int a)
        {
            datos.AsignarCategoria(a);
        }

    }
}
