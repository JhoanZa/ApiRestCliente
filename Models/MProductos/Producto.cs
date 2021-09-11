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
        public int IdProducto { get; set; }

        public String CorreoVendedor { get; set; }

        public String Categoria { get; set; }

        public String Nombre { get; set; }

        public String Descripcion { get; set; }

        public int CantidadDisponible { get; set; }

        public decimal ValorVenta { get; set; }
    }
}
