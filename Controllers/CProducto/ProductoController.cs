using ApiRestCliente.Controllers.CUsuarios;
using ApiRestCliente.Gestores;
using ApiRestCliente.Models;
using ApiRestCliente.Models.MProductos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiRestCliente.Controllers.CProducto
{
    public class ProductoController : Controller 
    {
        public IActionResult Index()
        {
            UsuarioController.Datos.CargarProductos(GestorProductos.ConsultarProductoCorreo(UsuarioController.Datos.Usuario.Correo));
            return View(UsuarioController.Datos);
        }

        public IActionResult Categoria()
        {
            if (UsuarioController.Datos.Categorias == null || UsuarioController.Datos.Categorias.Count < 1)
            {
                UsuarioController.Datos.AgregarCategorias(GestorCategoria.ConsultarCategorias());
            }
            return View(UsuarioController.Datos);
        }
        public IActionResult CategoriaP2()
        {
            return View(UsuarioController.Datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoriaP2(string NombreProducto, string Descripcion, int CantidadDisponible, decimal ValorVenta)
        {
            bool realizado = false;
            UsuarioController.Datos.Producto.CorreoVendedor = UsuarioController.Datos.Usuario.Correo;
            UsuarioController.Datos.Producto.Nombre = NombreProducto;
            UsuarioController.Datos.Producto.Descripcion = Descripcion;
            UsuarioController.Datos.Producto.CantidadDisponible = CantidadDisponible;
            UsuarioController.Datos.Producto.ValorVenta = ValorVenta;
            await Task.Run(() =>
            {
                if (UsuarioController.Datos.Producto.IdProducto != 0)
                {
                    realizado = GestorProductos.ModificarProducto(UsuarioController.Datos.Producto);
                }
                else
                {
                    realizado = GestorProductos.RegistrarProducto( UsuarioController.Datos.Producto);
                }
            });
            if (realizado)
            {
                UsuarioController.Datos.CargarProductos(GestorProductos.ConsultarProductoCorreo(UsuarioController.Datos.Usuario.Correo));
                return View("Index", UsuarioController.Datos);
            }
            return View("CategoriaP2");
        }

        public IActionResult Detalles(int? id )
        {
            UsuarioController.Datos.AsignarProducto(id);
            return View(UsuarioController.Datos);
        }
        public IActionResult Modificar(int? id)
        {
            if (UsuarioController.Datos.Producto.IdProducto != id && id != null)
            {
                UsuarioController.Datos.AsignarProducto(id);
            }
            return View(UsuarioController.Datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar([Bind("IdProducto,CorreoVendedor,Categoria,Nombre,Descripcion,CantidadDisponible,ValorVenta")] Producto producto)
        {
            producto.CorreoVendedor = UsuarioController.Datos.Producto.CorreoVendedor;

            if (ModelState.IsValid)
            {
                await Task.Run(() =>
                {
                    GestorProductos.ModificarProducto(producto);
                    UsuarioController.Datos.CargarProductos(GestorProductos.ConsultarProductoCorreo(UsuarioController.Datos.Usuario.Correo));
                });
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            await Task.Run(() =>
            {
                GestorProductos.EliminarProducto(Convert.ToInt32(id));
                UsuarioController.Datos.CargarProductos(GestorProductos.ConsultarProductoCorreo(UsuarioController.Datos.Usuario.Correo));
            });
            return View("Index",UsuarioController.Datos);
        }

        //Metodos para manipular los datos

        public void AgregarCategoria(int a)
        {
            UsuarioController.Datos.AsignarCategoria(a);
        }

    }
}
