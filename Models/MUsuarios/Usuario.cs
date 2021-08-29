using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCliente.Models.MUsuarios
{
    public class Usuario
    {
        public Usuario()
        {
            TipoUsuario = 1;
            PrimerNombre = "Visitante";
            SegundoNombre = "";
            PrimerApellido = "";
            SegundoNombre = "";
        }

        [JsonProperty(PropertyName = "tipoUsuario")]
        public int TipoUsuario { get; set; }

        [Required(ErrorMessage = "El campo --Primer nombre-- es requerido.")]
        [Display(Name = "Primer nombre:")]
        [JsonProperty(PropertyName = "primerNombre")]
        public String PrimerNombre { get; set; }

        [Display(Name = "Segundo nombre:")]
        [JsonProperty(PropertyName = "segundoNombre")]
        public String SegundoNombre { get; set; }

        [Required(ErrorMessage = "El campo --Primer apellido-- es requerido.")]
        [Display(Name = "Primer apellido:")]
        [JsonProperty(PropertyName = "primerApellido")]
        public String PrimerApellido { get; set; }

        [Display(Name = "Segundo apellido:")]
        [JsonProperty(PropertyName = "segundoApellido")]
        public String SegundoApellido { get; set; }

        [Required(ErrorMessage = "El campo --Fecha de nacimiento-- es requerido")]
        [Display(Name = "Fecha de nacimiento:")]
        [JsonProperty(PropertyName = "fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo --Edad- es requerido.")]
        [Display(Name = "Edad:")]
        [JsonProperty(PropertyName = "edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo --Correo-- es requerido.")]
        [Display(Name = "Correo:")]
        [JsonProperty(PropertyName = "correo")]
        public String Correo { get; set; }

        [Required(ErrorMessage = "El campo --contraseña-- es requerido.")]
        [Display(Name = "Contraseña:")]
        [JsonProperty(PropertyName = "contrasena")]
        public String Contrasena { get; set; }

    }
}
