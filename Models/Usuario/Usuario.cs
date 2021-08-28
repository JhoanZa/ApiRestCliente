using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCliente.Models
{
    public class Usuario
    {

        [JsonProperty(PropertyName = "tipoUsuario")]
        public int TipoUsuario { get; set; }

        [JsonProperty(PropertyName = "primerNombre")]
        public String PrimerNombre { get; set; }

        [JsonProperty(PropertyName = "segundoNombre")]
        public String SegundoNombre { get; set; }

        [JsonProperty(PropertyName = "primerApellido")]
        public String PrimerApellido { get; set; }

        [JsonProperty(PropertyName = "segundoApellido")]
        public String SegundoApellido { get; set; }

        [JsonProperty(PropertyName = "fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonProperty(PropertyName = "edad")]
        public int Edad { get; set; }

        [JsonProperty(PropertyName = "correo")]
        public String Correo { get; set; }

        [JsonProperty(PropertyName = "contrasena")]
        public String Contrasena { get; set; }

    }
}
