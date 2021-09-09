using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCliente.Models.MDomicilios
{
    public class Municipio
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "idDepartamento")]
        public int IdDepartamento { get; set; }

        [JsonProperty(PropertyName = "nombreMunicipio")]
        [Display(Name = "Municipio:")]
        public String NombreMunicipio { get; set; }
    }
}
