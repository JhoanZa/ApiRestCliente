using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCliente.Models.MDomicilios
{
    public class Domicilio
    {
        public Domicilio()
        {
            Direccion = "";
            NombreDepartamento = "";
            NombreMunicipio = "";
        }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "correoAsociado")]
        public String CorreoAsociado { get; set; }

        [Required(ErrorMessage = "El campo -- Dirección -- es requerido.")]
        [JsonProperty(PropertyName = "direccion")]
        [Display(Name = "Dirección:")]
        public String Direccion { get; set; }

        [JsonProperty(PropertyName = "nombreDepartamento")]
        [Display(Name = "Departamento:")]
        public String NombreDepartamento { get; set; }

        [JsonProperty(PropertyName = "nombreMunicipio")]
        [Display(Name = "Municipio")]
        public String NombreMunicipio { get; set; }
    }
}
