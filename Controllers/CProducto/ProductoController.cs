using ApiRestCliente.Controllers.CUsuarios;
using ApiRestCliente.Gestores;
using ApiRestCliente.Models;
using ApiRestCliente.Models.MProductos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiRestCliente.Controllers.CProducto
{
    public class ProductoController : Controller 
    {
        private ListaDatos datos = UsuarioController.Datos; 
        public IActionResult Index()
        {
            datos.CargarProductos(GestorProductos.ConsultarProductos());
            return View(datos);
        }

        public IActionResult Categoria()
        {
            if (datos.Categorias == null)
            {
                datos.AgregarCategorias(GestorCategoria.ConsultarCategorias());
            }
            return View(datos);
        }
        public IActionResult CategoriaP2()
        {
            return View(datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoriaP2(string NombreProducto, string Descripcion, int CantidadDisponible, decimal ValorVenta)
        {
            bool realizado = false;
            Producto producto = new Producto();
            producto.CorreoVendedor = datos.Usuario.Correo;
            producto.Categoria = datos.NombreCategoria;
            producto.Nombre = NombreProducto;
            producto.Descripcion = Descripcion;
            producto.CantidadDisponible = CantidadDisponible;
            producto.ValorVenta = ValorVenta;
            await Task.Run(() =>
            {
                if (datos.IdProducto != 0)
                {
                    realizado = GestorProductos.ModificarProducto(producto);
                }
                else
                {
                    realizado = GestorProductos.RegistrarProducto(producto);
                }
            });
            if (realizado)
            {
                datos.CargarProductos(GestorProductos.ConsultarProductos());
                return View("Index", datos);
            }
            return View("Index");
        }


        //Metodos para manipular los datos

        public void AgregarCategoria(int a)
        {
            datos.AsignarCategoria(a);
        }

    }
}
