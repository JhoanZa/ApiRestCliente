using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCliente.Models.MProductos
{
    public class Producto
    {
        public Producto()
        {
            IdProducto = 0;
            CorreoVendedor = "";
            Categoria = "";
            Nombre = "";
            Descripcion = "";
            CantidadDisponible = 0;
            ValorVenta = 0;
        }

        public int IdProducto { get; set; }

        [Display(Name = "Correo del vendedor:")]
        public String CorreoVendedor { get; set; }

        [Display(Name = "Categoría:")]
        public String Categoria { get; set; }

        [Display(Name = "Nombre:")]
        public String Nombre { get; set; }

        [Display(Name = "Descripción:")]
        public String Descripcion { get; set; }

        [Display(Name = "Cantidad disponible:")]
        public int CantidadDisponible { get; set; }

        [Display(Name = "Valor:")]
        public decimal ValorVenta { get; set; }
    }
}
