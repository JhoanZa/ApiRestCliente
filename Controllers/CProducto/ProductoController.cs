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
            datos.Producto.CorreoVendedor = datos.Usuario.Correo;
            datos.Producto.Nombre = NombreProducto;
            datos.Producto.Descripcion = Descripcion;
            datos.Producto.CantidadDisponible = CantidadDisponible;
            datos.Producto.ValorVenta = ValorVenta;
            await Task.Run(() =>
            {
                if (datos.Producto.IdProducto != 0)
                {
                    realizado = GestorProductos.ModificarProducto(datos.Producto);
                }
                else
                {
                    realizado = GestorProductos.RegistrarProducto(datos.Producto);
                }
            });
            if (realizado)
            {
                datos.CargarProductos(GestorProductos.ConsultarProductos());
                return View("Index", datos);
            }
            return View("Index");
        }

        public IActionResult Detalles(int? id )
        {
            datos.AsignarProducto(id);
            return View(datos);
        }
        public IActionResult Modificar(int? id)
        {
            if (datos.Producto.IdProducto != id && id != null)
            {
                datos.AsignarProducto(id);
            }
            return View(datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar([Bind("IdProducto,CorreoVendedor,Categoria,Nombre,Descripcion,CantidadDisponible,ValorVenta")] Producto producto)
        {
            producto.CorreoVendedor = datos.Producto.CorreoVendedor;

            if (ModelState.IsValid)
            {
                await Task.Run(() =>
                {
                    GestorProductos.ModificarProducto(producto);
                    datos.CargarProductos(GestorProductos.ConsultarProductos());
                });
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Metodos para manipular los datos

        public void AgregarCategoria(int a)
        {
            datos.AsignarCategoria(a);
        }

    }
}
