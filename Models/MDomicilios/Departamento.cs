using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiRestCliente.Models.MDomicilios
{
    public class Departamento
    {
        [JsonProperty(PropertyName = "idDepartamento")]
        public int IdDepartamento { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        [Display(Name = "Departamento:")]
        public String Nombre { get; set; }
    }
}
