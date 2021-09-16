using ApiRestCliente.Controllers.CUsuarios;
using ApiRestCliente.Gestores;
using ApiRestCliente.Models;
using ApiRestCliente.Models.MProductos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiRestCliente.Controllers.CProducto
{
    /*
     * Esta clase se encarga de brindar toda la funcionalidad relacionada a los procesos que puede realizar un usuario tales como: Registrarse, Iniciar sesión, Modificar sus datos de residencia
     * y cambiar ciertos datos personales. 
     */
    public class ProductoController : Controller 
    {
        public IActionResult Index()
        {
            /*
             * En este metodo se carga primero los elementos almacenados en la base de datos relacionados a los productos, se cargan solamente
             * los que esten relacionados con el usuario mediante su correo.
            */
            UsuarioController.Datos.CargarProductos(GestorProductos.ConsultarProductoCorreo(UsuarioController.Datos.Usuario.Correo));
            return View(UsuarioController.Datos);
        }

        public IActionResult Categoria()
        {
            /*
             * Este método se encarga de generar la vista en la cual se selecciona la categoría correspondiente al artículo que se desea registrar. Las categorías son definidas por el 
             * administrador directamente en la BBDD. No se pueden añadir en este programa, solo se pueden consultar. Primero se consulta si el programa contiene algún registro almacenado
             * en caso de que no se tenga ninguno, se realiza la consulta en la BBDD usando el gestor designado para este tipo de datos.
             */
            if (UsuarioController.Datos.Categorias == null || UsuarioController.Datos.Categorias.Count < 1)
            {
                UsuarioController.Datos.AgregarCategorias(GestorCategoria.ConsultarCategorias());
            }
            return View(UsuarioController.Datos);
        }
        public IActionResult CategoriaP2()
        {
            /*
             * Este método solamente se encarga de carga la vista sobre la cual se debe llenar el formulario de datos sobre el producto a registrar.
             */
            return View(UsuarioController.Datos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoriaP2(string NombreProducto, string Descripcion, int CantidadDisponible, decimal ValorVenta)
        {
            /*
             * Método tipo post mediante el cual se cargan los datos ingresados en el formulario de registro para el producto, se reciben los datos para luego crear el objeto tipo
             * producto por lo general el producto se crea con identificador 0 en caso de que sea uno nuevo y se inicia en otro número correspondiente al código de un producto
             * existente en caso de que se desee modificar. El programa valida el código único del producto y si el valor es igual a cero crea uno nuevo, si el valor es distinto de 
             * cero se modifica los datos del producto que posee el código registrado
             */
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
