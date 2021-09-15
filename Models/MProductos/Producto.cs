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

        [JsonProperty(PropertyName = "idProducto")]
        [Display(Name = "Código")]
        public int IdProducto { get; set; }
        
        [Required]
        [Display(Name = "Correo del vendedor:")]
        [JsonProperty(PropertyName = "correoVendedor")]
        public String CorreoVendedor { get; set; }

        [Required]
        [Display(Name = "Categoría:")]
        [JsonProperty(PropertyName = "categoria")]
        public String Categoria { get; set; }


        [Required]
        [Display(Name = "Nombre del producto:")]
        [JsonProperty(PropertyName = "nombre")]
        public String Nombre { get; set; }

        [Required]
        [Display(Name = "Descripción:")]
        [JsonProperty(PropertyName = "descripcion")]
        public String Descripcion { get; set; }

        [Required]
        [Display(Name = "Cantidad disponible:")]
        [JsonProperty(PropertyName = "cantidadDisponible")]
        public int CantidadDisponible { get; set; }

        [Required]
        [Display(Name = "Costo del producto:")]
        [JsonProperty(PropertyName = "valorVenta")]
        public decimal ValorVenta { get; set; }
    }
}
